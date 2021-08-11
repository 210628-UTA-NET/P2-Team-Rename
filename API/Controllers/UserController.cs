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
using AutoMapper;
using API.Jwt;
using Entities.Dtos;
using Entities.Database;
using Entities.Query;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly JwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, JwtHandler jwtHandler, IMapper mapper) {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration) {
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

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new RegistrationResponseDto {
                IsSuccessfulRegistration = true,
                User = userDto
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationDto userAuthentication) {
            User user = await _userManager.FindByEmailAsync(userAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthentication.Password))
                return Unauthorized(new AuthenticationResponseDto { ErrorMessage = "Invalid Authentication" });

            SigningCredentials signingCredentials = _jwtHandler.GetSigningCredentials();
            List<Claim> claims = await _jwtHandler.GetClaims(user);
            JwtSecurityToken tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new AuthenticationResponseDto { 
                IsSuccessfulAuthentication = true, 
                Token = token,
                User = userDto
            });
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser() {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            UserDto userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        //[Authorize]
        [HttpGet("Search")]
        public async Task<IActionResult> QueryUsers([FromQuery] UserParameters userParameters) {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();

            var query = _userManager.Users;

            if (userParameters.Role != null) {
                if (!roles.Contains(userParameters.Role)) {
                    return BadRequest();
                } else {
                    query = (await _userManager.GetUsersInRoleAsync(userParameters.Role)).AsQueryable();
                }
            }

            if (userParameters.Name != null) {
                query = query.Where(u => u.FirstName.Contains(userParameters.Name) || u.LastName.Contains(userParameters.Name));
            }

            if (userParameters.Distance != null && userParameters.Longitude != null && userParameters.Latitude != null) {
                var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
                var location = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate((double)userParameters.Longitude, (double)userParameters.Latitude));
                query = query.Where(u => u.Location.IsWithinDistance(location, (double) userParameters.Distance));
            }

            var results = await query.ToListAsync();
            IList<UserDto> userResults = _mapper.Map<List<UserDto>>(results);


            return Ok(new { Results = userResults });
        }

        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUser([FromRoute] string userId) {
            User target = await _userManager.FindByIdAsync(userId);
            if (target == null) return BadRequest();

            await _userManager.DeleteAsync(target);

            return Ok(new { Results = string.Format("User with id: {0} successfully deleted.", userId) });
        }
    }
}
