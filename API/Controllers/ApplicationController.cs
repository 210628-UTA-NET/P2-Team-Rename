using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Entities.Database;
using Entities.Dtos;
using Entities.Query;
using BL;
using AutoMapper;
using System.Security.Claims;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase {
        private readonly TutorApplicationManager _appManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ApplicationController(TutorApplicationManager appManager, UserManager<User> userManager, IMapper mapper) {
            _appManager = appManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Administrator")]
        [HttpGet()]
        public async Task<IActionResult> GetApplications([FromQuery] TutorAppParameters tutorAppParams) {
            if (!ModelState.IsValid) return BadRequest();

            IList<TutorApplication> results = await _appManager.GetTutorApplications(tutorAppParams);
            if (results == null) return StatusCode(500);

            IList<TutorApplicationDto> resultsDto = _mapper.Map<IList<TutorApplication>, IList<TutorApplicationDto>>(results);

            return Ok(new { Results = resultsDto });
        }

        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> SubmitApplication([FromBody] SubmitTutorApplicationDto applicationDto) {
            if (!ModelState.IsValid) return BadRequest();
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return StatusCode(500);

            TutorApplication newApp = await _appManager.CreateTutorApplication(applicationDto, user.Id);
            if (newApp == null) return BadRequest();
            return Ok(newApp);
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost("approve")]
        public IActionResult ApproveApplication(int id, bool approve) {
            return Ok();
        }
    }
}
