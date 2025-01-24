using Microsoft.AspNetCore.Mvc;
using Candidate.Hub.Entities.Model;
using Candidate.Hub.Entities.DTO;
using Candidate.Hub.Repository.Repository;

namespace Candidate.Hub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController(IRepositoryService repositoryService) : ControllerBase
    {

        [HttpPost]
        [Route("AddOrUpdate")]
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidateDto candidate)
        {
            if (candidate is not null)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Candidate data is required."
                });
            }

            if (!ModelState.IsValid)
            {
                //validation
                return BadRequest(new
                {
                    IsSuccess = true,
                    Message = "Invalid candidate data.",
                    Errors = ModelState.Values
                        .Where(v => v.Errors.Count > 0)
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList()
                });
            }

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

            try
            {
                var updatedCandidate = await repositoryService.AddOrUpdateCandidate(candidateDetails);

                if (updatedCandidate != null)
                {
                    //will require Id if manipulation is using id in frontend lets say from table
                    
                    return Ok(new ApiResponse
                    {
                        IsSuccess = true,
                        Message = "Candidate data successfully updated.",
                        Result = candidate
                    });
                }

                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Unable to create or update the candidate."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    IsSuccess = false,
                    Message = "An error occurred while processing the request.",
                    Errors = [ex.Message]
                });
            }
        }

    }
}
