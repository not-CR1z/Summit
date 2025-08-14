using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummitChallenges.Models;
using SummitChallenges.Services;
using System.Text.Json;

namespace SummitChallenges.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class JournalController : ControllerBase
    {
        [HttpPost("invoicesGet")]
        public IActionResult GetJournals(User user)
        {
            JournalService journalService = new JournalService();
            string journalsRetrieve = journalService.GetJournalsByUser(user.UserLogOn);
            return Ok(new { journals = journalsRetrieve });
        }
    }
}