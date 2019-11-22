using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GradProject.Core;
using GradProject.Models;
using GradProject.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradProject.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }

        // POST api/values
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            // create a new domain user and email, name, etc
            var newUser = new User
            {
                UserName = registration.UserName,
                

                // note that we do NOT assign password. Instead of a Password property, there is
                // PaswordHashed, which will be assigned when we create the user. It will store
                // the password in a secure form.
            };
            // use UserMager to create a new User. Pass in the password so it can be hashed.
            var result = await _userManager.CreateAsync(newUser, registration.Password);
            if (result.Succeeded)
            {
                return Ok(newUser.ToApiModel());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        // POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            // try to authenticate user
            var user = await AuthenticateUserAsync(login.Username, login.Password);

            // if we successfully authenticated...
            if (user != null)
            {
                // generate and return the token
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, UserName = login.Username });
            }

            return response;
        }

        private string GenerateJSONWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // retrieve secret key from configuration
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            // create signing credentials using secrety key
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;
            // set up claims containing additional info that will be stored in token
            var claims = new List<Claim>
            {
                
             };
            // add role claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            // create the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);
            return tokenHandler.WriteToken(token);
        }

        private async Task<User> AuthenticateUserAsync(string userName, string password)
        {
            // retrieve the user by username and then check password
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}
