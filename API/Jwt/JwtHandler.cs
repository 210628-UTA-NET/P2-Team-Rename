using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Database;

namespace API.Jwt {
    public class JwtHandler {
        private readonly IConfigurationSection _jwtSettings;
        private readonly UserManager<User> _userManager;

        public JwtHandler(IConfiguration configuration, UserManager<User> userManager) {
            _jwtSettings = configuration.GetSection("JwtSettings");
            _userManager = userManager;
        }

        public SigningCredentials GetSigningCredentials() {
            byte[] key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            SymmetricSecurityKey secret = new(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<List<Claim>> GetClaims(User user) {
            List<Claim> claims = new() {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) {
            JwtSecurityToken tokenOptions = new(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }
}