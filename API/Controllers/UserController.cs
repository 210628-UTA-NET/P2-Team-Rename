using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using DL.Entities;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager) {
            _userManager = userManager;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistration userRegistration) {
            if (userRegistration == null || !ModelState.IsValid) return BadRequest();

            var user = new User {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
            };
            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if (!result.Succeeded) {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponse { Errors = errors });
            }

            return StatusCode(201);
        }
    }
}
