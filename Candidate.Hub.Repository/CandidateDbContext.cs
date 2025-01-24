using Candidate.Hub.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Hub.Repository
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateDetails> CandidateDetails { get; set; }
    }


}
