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
using NetTopologySuite.Geometries;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase {
        private readonly TutorManager _tutorManager;
        private readonly IMapper _mapper;
        public TutorController(TutorManager tutorManager, IMapper mapper) {
            _tutorManager = tutorManager;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetTutorsForUser([FromQuery] TutorParameters tutorParams) {
            if (!ModelState.IsValid) return BadRequest(new { Error = "Invalid query parameters." });

            IList<Tutor> results = await _tutorManager.GetTutors(tutorParams);
            IList<TutorDto> resultsDto = _mapper.Map<IList<Tutor>, IList<TutorDto>>(results);

            if (tutorParams.Distance != null && tutorParams.Latitude != null && tutorParams.Longitude != null) {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new Coordinate((double)tutorParams.Longitude, (double)tutorParams.Latitude));

                foreach (TutorDto tutor in resultsDto) {
                    if (tutor.Location != null) {
                        var tutorLocation = geometryFactory.CreatePoint(new Coordinate(tutor.Location.Latitude, tutor.Location.Longitude));
                        tutor.Distance = tutorLocation.Distance(location);
                    }
                }
            }

            return Ok(new { Results = resultsDto});
        }
    }
}
