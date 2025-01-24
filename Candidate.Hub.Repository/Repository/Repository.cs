using Candidate.Hub.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Hub.Repository.Repository
{
    public class Repository : IRepository
    {
        //need to add db context.
        public async Task<CandidateDetails> AddOrUpdateCandidate(CandidateDetails candidate)
        {

            var existingCandidate = await _dbContext.Candidates
                .FirstOrDefaultAsync(c => c.Email == candidate.Email && c.FirstName == candidate.FirstName && c.LastName == candidate.LastName);

            if (existingCandidate != null)
            {
                // Update existing candidate
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.PreferredCallTime = candidate.PreferredCallTime;
                existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
                existingCandidate.GitHubUrl = candidate.GitHubUrl;
                existingCandidate.Comment = candidate.Comment;

                _dbContext.Candidates.Update(existingCandidate);
            }
            else
            {
                await _dbContext.Candidates.AddAsync(candidate);
            }

            await _dbContext.SaveChangesAsync();

        }
    }
}
