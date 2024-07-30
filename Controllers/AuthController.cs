using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using store.Models;
using store.Data;
using Microsoft.Extensions.Configuration;
using store.Data;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly storeContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(storeContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user == null)
            {
                  
                return Unauthorized();
            
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token,
                            id=user.Id,
                            FullName = user.FullName,
                            Email = user.Email,
                            Type = user.type,
                            PhoneNumber = user.PhoneNumber

            });
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {    
                new Claim(JwtRegisteredClaimNames.Sub, user.Email ),
                                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString() ),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
