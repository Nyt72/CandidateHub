using Candidate.Hub.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Hub.Repository.Repository
{
    public interface IRepository
    {
        Task<CandidateDetails> AddOrUpdateCandidate(CandidateDetails candidate);
    }
}
