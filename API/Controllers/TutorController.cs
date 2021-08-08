using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Database;
using BL;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase {
        public TutorController() {
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetTutorsForUser([FromQuery] int distance, [FromQuery] string sortBy) {
            return Ok();
        }
    }
}
