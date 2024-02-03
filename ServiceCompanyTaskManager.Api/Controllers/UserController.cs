using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceCompanyTaskManager.Api.DbContexts;
using ServiceCompanyTaskManager.Api.Models;
using ServiceCompanyTaskManager.Api.Services;
using ServiceCompanyTaskManager.Common.Models;
using ServiceCompanyTaskManager.Common.Models.Enums;

namespace ServiceCompanyTaskManager.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ServiceCompanyDbContext _dbContext;
        private readonly UserService _userService;

        public UserController(ServiceCompanyDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult TestApi()
        {
            return Ok("test");
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                _userService.Create(userModel);

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("add/all")]
        public async Task<IActionResult> AddMultipleUsersAsync([FromBody] List<UserModel> userModels)
        {
            _userService.AddMultipleUsersAsync(userModels);
            return Ok();
        }

        [HttpPatch("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                _userService.Update(id, userModel);

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService?.Delete(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _dbContext.Users.Select(u => u.ToDto()).ToListAsync();
        }
    }
}

