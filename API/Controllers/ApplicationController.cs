using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Database;
using Entities.Dtos;
using Entities.Query;
using BL;
using AutoMapper;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase {
        private readonly TutorApplicationManager _appManager;
        private readonly IMapper _mapper;

        public ApplicationController(TutorApplicationManager appManager, IMapper mapper) {
            _appManager = appManager;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Administrator")]
        [HttpGet()]
        public async Task<IActionResult> GetApplications([FromQuery] TutorAppParameters tutorAppParams) {
            if (!ModelState.IsValid) return BadRequest();

            IList<TutorApplication> results = await _appManager.GetTutorApplications(tutorAppParams);
            IList<TutorApplicationDto> resultsDto = _mapper.Map<IList<TutorApplication>, IList<TutorApplicationDto>>(results);

            if (results == null) { 
                return StatusCode(500);
            }
            return Ok(new { Results = resultsDto });
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
