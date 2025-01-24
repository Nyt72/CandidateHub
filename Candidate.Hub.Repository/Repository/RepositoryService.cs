using Candidate.Hub.Entities.Model;
using Candidate.Hub.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Hub.Repository
{
    public class RepositoryService(CandidateDbContext candidateDbContext) : IRepositoryService
    {
        public async Task AddOrUpdateCandidate(CandidateDetails candidate)
        {

            //var existingCandidate = await candidateDbContext.CandidateDetails
            //    .FirstOrDefaultAsync(c => c.Email == candidate.Email && c.FirstName == candidate.FirstName && c.LastName == candidate.LastName);

            //if (existingCandidate != null)
            //{
            //    // Update existing candidate
            //    existingCandidate.FirstName = candidate.FirstName;
            //    existingCandidate.LastName = candidate.LastName;
            //    existingCandidate.PhoneNumber = candidate.PhoneNumber;
            //    existingCandidate.TimeInterval = candidate.TimeInterval;
            //    existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
            //    existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
            //    existingCandidate.Comments = candidate.Comments;

            //    candidateDbContext.CandidateDetails.Update(existingCandidate);
            //}
            //else
            //{
            //    candidate.Id = new Guid();
            //    await candidateDbContext.CandidateDetails.AddAsync(candidate);
            //}

         //   await candidateDbContext.SaveChangesAsync();

        }
    }
}
