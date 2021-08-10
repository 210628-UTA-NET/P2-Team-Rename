using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
using NetTopologySuite;
using System.Security.Claims;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase {
        private readonly TutorManager _tutorManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public TutorController(TutorManager tutorManager, UserManager<User> userManager, IMapper mapper) {
            _tutorManager = tutorManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetTutorsForUser([FromQuery] TutorParameters tutorParams) {
            if (!ModelState.IsValid) return BadRequest();

            IList<Tutor> results = await _tutorManager.GetTutors(tutorParams);
            IList<TutorDto> resultsDto = _mapper.Map<IList<Tutor>, IList<TutorDto>>(results);

            if (tutorParams.Distance != null && tutorParams.Latitude != null && tutorParams.Longitude != null) {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate((double)tutorParams.Longitude, (double)tutorParams.Latitude));

                foreach (TutorDto tutor in resultsDto) {
                    tutor.Distance = tutor.Location.Distance(location);
                }
            }

            return Ok(new { Results = resultsDto});
        }


        [Authorize]
        [HttpPut("request")]
        public async Task<IActionResult> RequestFollowTutor([FromRoute] string tutorId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            Tutor tutor = await _tutorManager.FindByIdAsync(tutorId);
            if (tutor == null) return BadRequest();

            //To be implemented send request to tutor.

            //temp
            user.MyTutors.Add(tutor);

            await _userManager.UpdateAsync(user);
            return Ok();
        }

        /*
        [Authorize]
        [HttpPut("approve")]
        public async Task<IActionResult> ApproveFollowRequest([FromRoute] string followRequestId) {

        }*/
    }
}
