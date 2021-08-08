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
    public class AppointmentController : ControllerBase {
        private readonly AppointmentManager _appointmentManager;
        private readonly UserManager<User> _userManager;

        public AppointmentController(AppointmentManager appointmentManager, UserManager<User> userManager) {
            _appointmentManager = appointmentManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] AppointmentParameters appointmentParameters) {
            if (!ModelState.IsValid) return BadRequest();

            IList<Appointment> results = await _appointmentManager.GetAppointments(appointmentParameters);

            return Ok(new { Results = results });
        }

        [Authorize]
        [HttpGet("cancel")]
        public async Task<IActionResult> CancelAppointment([FromRoute]string appointmentId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string result = await _appointmentManager.CancelAppointment(appointmentId, userId);

            return Ok(new { Status = result });
        }

        [Authorize(Roles = "Tutor")]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] DateTime? date, int minuteLength) {
            string tutorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Appointment result = await _appointmentManager.CreateAppointment(tutorId, date, minuteLength);

            return Ok(new { Results = result });
        }

        [Authorize]
        [HttpGet("book")]
        public async Task<IActionResult> BookAppointment([FromRoute] string appointmentId) {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Appointment result = await _appointmentManager.BookAppointment(appointmentId, userId);

            return Ok(new { Results = result });
        }
    }
}