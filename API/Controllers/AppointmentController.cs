using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Entities.Database;
using Entities.Query;
using BL;
using System.Security.Claims;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase {
        private readonly AppointmentManager _appointmentManager;

        public AppointmentController(AppointmentManager appointmentManager) {
            _appointmentManager = appointmentManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentParameters appointmentParameters) {
            if (!ModelState.IsValid) return BadRequest(new { Error = "Invalid query parameters." });

            IList<Appointment> results = await _appointmentManager.GetAppointments(appointmentParameters);

            return Ok(new { Results = results });
        }

        [Authorize]
        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> CancelAppointment([FromRoute] string appointmentId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string result = await _appointmentManager.CancelAppointment(appointmentId, userId);

            return Ok(new { Status = result });
        }

        [Authorize(Roles = "Tutor")]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentParameters createAppointmentParameters) {
            string tutorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Appointment result = await _appointmentManager.CreateAppointment(tutorId, createAppointmentParameters.Date, createAppointmentParameters.MinuteLength);

            return Ok(new { Results = result });
        }

        [Authorize]
        [HttpPatch("book/{appointmentId}")]
        public async Task<IActionResult> BookAppointment([FromRoute] string appointmentId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Appointment result = await _appointmentManager.BookAppointment(appointmentId, userId);

            return Ok(new { Results = result });
        }
    }
}