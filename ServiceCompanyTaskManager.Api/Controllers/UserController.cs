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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);

            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult CreateUser([FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                var result = _userService.Create(userModel);

                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPost("add/all")]
        public async Task<IActionResult> CreateMultipleUsersAsync([FromBody] List<UserModel> userModels)
        {
            if (userModels != null && userModels.Count > 0)
            {
                var result = _userService.CreateMultipleUsersAsync(userModels);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPatch("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                var result = _userService.Update(id, userModel);

                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.Delete(id);

            return result ? Ok() : NotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _dbContext.Users.Select(u => u.ToDto()).ToListAsync();
        }
    }
}

