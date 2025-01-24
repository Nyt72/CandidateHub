using Microsoft.AspNetCore.Mvc;
using Candidate.Hub.Entities.Model;

namespace Candidate.Hub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {

        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidateDetails candidate)
        {
            if (candidate == null)
            {
                return BadRequest("Candidate data is required.");
            }
            if (ModelState.IsValid)
            {

            }

            return Ok("Candidate data successfully upserted.");
        }
    }
}
