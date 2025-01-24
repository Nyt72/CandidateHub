using Candidate.Hub.Entities.Model;
using Candidate.Hub.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Hub.Repository
{
    public class RepositoryService(CandidateDbContext candidateDbContext) : IRepositoryService
    {
        public async Task<CandidateDetails?> AddOrUpdateCandidate(CandidateDetails candidate)
        {

            //unique validation 
            var existingCandidate = await candidateDbContext.CandidateDetails
                .FirstOrDefaultAsync(c => c.Email == candidate.Email && c.FirstName == candidate.FirstName && c.LastName == candidate.LastName);

            if (existingCandidate != null)
            {
                // Update existing candidate
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.TimeInterval = candidate.TimeInterval;
                existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
                existingCandidate.Comments = candidate.Comments;

                candidateDbContext.CandidateDetails.Update(existingCandidate);
            }
            else
            {
                //add new guid 
                candidate.Id = new Guid();
                await candidateDbContext.CandidateDetails.AddAsync(candidate);
            }

            if (await candidateDbContext.SaveChangesAsync() > 0)
            {
                return candidate;
            }
            else
            {
                return null;
            }
           

        }
    }
}
