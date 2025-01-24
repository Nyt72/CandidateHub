using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candidate.Hub.Api.Controllers;
using Candidate.Hub.Repository.Repository;
using Candidate.Hub.Entities.DTO;
using Candidate.Hub.Entities.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Candidate.Hub.Api.Tests
{
    [TestFixture]
    public class CandidateControllerTests
    {
        private Mock<IRepositoryService> _mockRepositoryService;
        private CandidateController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepositoryService = new Mock<IRepositoryService>();
            _controller = new CandidateController(_mockRepositoryService.Object);      
        }

        [Test]
        public async Task AddOrUpdateCandidate_NullCandidate_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.AddOrUpdateCandidate(null);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
            var response = badRequestResult.Value as ApiResponse;
            if (response is not null)
            {
                Assert.That(response.IsSuccess, Is.EqualTo(false));
                Assert.That(response.Message, Is.EqualTo("Candidate data is required."));
            }
        }

        [Test]
        public async Task AddOrUpdateCandidate_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Email is required.");
            var candidate = new CandidateDto();

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidate);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
            var response = badRequestResult.Value as ApiResponse;
            if (response is not null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.IsSuccess, Is.EqualTo(false));
                    Assert.That(response.Message, Is.EqualTo("Invalid candidate data."));
                    Assert.That(response.Errors, Does.Contain("Email is required."));
                });
            }
        }

        [Test]
        public async Task AddOrUpdateCandidate_RepositoryReturnsCandidate_ReturnsOk()
        {
            // Arrange
            var candidate = new CandidateDto
            {
                FirstName = "Nitesh",
                LastName = "Lama",
                Email = "nitesh.lama@gmail.com",
                PhoneNumber = "1234567890",
                LinkedInProfileUrl = "https://linkedin.com/in/nlama2",
                GitHubProfileUrl = "https://github.com/nyt72",
                Comments = "Test Demo Trial"
            };

            var candidateDetails = new CandidateDetails
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                PhoneNumber = candidate.PhoneNumber,
                LinkedInProfileUrl = candidate.LinkedInProfileUrl,
                GitHubProfileUrl = candidate.GitHubProfileUrl,
                Comments = candidate.Comments
            };

            _mockRepositoryService
             .Setup(s => s.AddOrUpdateCandidate(It.IsAny<CandidateDetails>()))
             .ReturnsAsync(candidateDetails);

            // Act
            var result = await _controller.AddOrUpdateCandidate(candidate);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            var response = okResult.Value as ApiResponse;
            if (response is not null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.IsSuccess, Is.EqualTo(true));
                    Assert.That(response.Message, Is.EqualTo("Candidate data successfully updated."));
                    Assert.That(response.Result, Is.EqualTo(candidate));
                });
            }
        }

    }
}
