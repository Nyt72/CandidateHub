using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Hub.Entities.DTO
{
    public class CandidateDto
    {
        [Required(ErrorMessage = "First Name is required")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }
        public string? TimeInterval { get; set; } //eg. 10AM
        public string? LinkedInProfileUrl { get; set; }
        public string? GitHubProfileUrl { get; set; }
        [Required]
        public required string Comments { get; set; }
    }
}
