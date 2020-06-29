using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DemoApp.API.Data;
using DemoApp.API.Dtos;
using DemoApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DemoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, DataContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
            _repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _repo.Login(userLoginDto.Email, userLoginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            //Token Building Token
            var claims = new[]
            {
                    //One claim is ID
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //The other claim is username
                    new Claim(ClaimTypes.Name, user.Email)
                };

            //Get our key stored in app settings and encode it
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            //Creating signing in creds from the key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //We create a token descriptor containing the claims, expiry date and creds created above
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            //Prep a tokenHandler
            var tokenHandler = new JwtSecurityTokenHandler();

            //Give it the descriptor (with all data) and creating the token!
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if(await _repo.UserExists(userRegisterDto.Email)) return BadRequest("user already exists");

            var user = new User{
                Name = userRegisterDto.Name,
                Country = userRegisterDto.Country,
                City = userRegisterDto.City,
                PersonalInfo = userRegisterDto.PersonalInfo,
                ImageUrl = userRegisterDto.ImageUrl,
                Email = userRegisterDto.Email,
                LastLogin = DateTime.Now
            };

            var createdUser = await _repo.Register(user, userRegisterDto.Password);

            return StatusCode(201);
        }
    }
}