using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DL.Entities;
using BL;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase {
        private readonly TutorApplicationManager _appManager;
        public TutorController(TutorApplicationManager appManager) {
            _appManager = appManager;
        }

        //[Authorize]
        [HttpGet("application")]
        public async Task<IActionResult> GetApplications() {
            IList<TutorApplication> results = await _appManager.GetTutorApplications();

            if (results == null) { 
                return StatusCode(500);
            }

            return Ok(new { Results = results });
        }

        [HttpPost("application")]
        public async Task<IActionResult> SubmitApplication() {
            IList<TutorApplication> results = await _appManager.GetTutorApplications();

            if (results == null) { 
                return StatusCode(500);
            }

            return Ok(new { Results = results });
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTutorsForUser([FromQuery] int distance, [FromQuery] string sortBy) {

            return Ok();
        }
    }
}
