using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Candidate.Hub.Entities.Model
{
    public class CandidateDetails
    {
        [Key]
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }      
        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? TimeInterval { get; set; } //eg. 10AM
        public string? LinkedInProfileUrl { get; set; }
        public string? GitHubProfileUrl { get; set; }
        public required string Comments { get; set; }
    }
}
