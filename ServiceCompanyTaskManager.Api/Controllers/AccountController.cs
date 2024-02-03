using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServiceCompanyTaskManager.Api.DbContexts;
using ServiceCompanyTaskManager.Api.Services;
using ServiceCompanyTaskManager.Common.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ServiceCompanyTaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ServiceCompanyDbContext _dbContext;

        private readonly UserService _userService;

        public AccountController(ServiceCompanyDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        [Authorize]
        [HttpPatch("update")]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                string userName = HttpContext.User.Identity.Name;

                var user = _dbContext.Users.SingleOrDefault(u => u.Email == userName);

                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.Avatar = userModel.Avatar;
                    user.PhoneNumber = userModel.PhoneNumber;
                    user.Password = userModel.Password;
                    user.Description = userModel.Description;
                    user.ShortName = userModel.ShortName;

                    _dbContext.SaveChanges();

                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet("user/info")]
        public IActionResult GetCurrentUser()
        {
            string userName = HttpContext.User.Identity.Name;
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == userName);

            if (user != null)
            {
                return Ok(user.ToDto());
            }

            return NotFound();
        }

        [HttpPost("token")]
        public IActionResult GetToken()
        {
            var user = _userService.GetLoginPassByBaseAuth(Request);

            var login = user.Item1;
            var password = user.Item2;

            var identity = _userService.GetIdentity(login, password);

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: DateTime.Now,
                claims: identity.Claims,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }
    } 
}
