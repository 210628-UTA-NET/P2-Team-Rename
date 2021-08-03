using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using DL.Entities;
using API.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly UserManager<User> _userManager;
        private readonly JwtHandler _jwtHandler;
        public UserController(UserManager<User> userManager, JwtHandler jwtHandler) {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistration userRegistration) {
            if (userRegistration == null || !ModelState.IsValid) return BadRequest();

            User user = new() {
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, userRegistration.Password);
            if (!result.Succeeded) {
                IEnumerable<string> errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponse { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthentication userAuthentication) {
            User user = await _userManager.FindByEmailAsync(userAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthentication.Password))
                return Unauthorized(new AuthenticationResponse { ErrorMessage = "Invalid Authentication" });

            SigningCredentials signingCredentials = _jwtHandler.GetSigningCredentials();
            List<Claim> claims = _jwtHandler.GetClaims(user);
            JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthenticationResponse { IsSuccessfulAuthentication = true, Token = token });
        }

        //Testing that authentication works
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser() {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByIdAsync(id);

            Console.WriteLine(user.ToString());

            return Ok();
        }
    }
}
