using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DL.Entities;
using API.Entities;
using BL;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase {
        private readonly TutorApplicationManager _appManager;
        public ApplicationController(TutorApplicationManager appManager) {
            _appManager = appManager;
        }

        //[Authorize(Roles = "Administrator")]
        [HttpGet()]
        public async Task<IActionResult> GetApplications() {
            IList<TutorApplication> results = await _appManager.GetTutorApplications();

            if (results == null) { 
                return StatusCode(500);
            }

            return Ok(new { Results = results });
        }

        //[Authorize]
        [HttpPost()]
        public IActionResult SubmitApplication([FromBody] SubmitTutorApplicationDto applicationDto) {
            return Ok();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost("approve")]
        public IActionResult ApproveApplication(int id, bool approve) {
            return Ok();
        }
    }
}
