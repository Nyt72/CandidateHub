using Candidate.Hub.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Hub.Entities.Model
{
    public class ApiResponse
    {
        public bool IsSuccess { get;set; } = false;
        public string? Message { get; set;}          
        public CandidateDto? Result { get; set; }
        public List<string>? Errors { get; set; }    
    }
}
