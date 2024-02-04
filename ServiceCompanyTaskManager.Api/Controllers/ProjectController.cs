using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceCompanyTaskManager.Api.DbContexts;
using ServiceCompanyTaskManager.Api.Models;
using ServiceCompanyTaskManager.Api.Services;
using ServiceCompanyTaskManager.Common.Models;

namespace ServiceCompanyTaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ServiceCompanyDbContext _dbContext;
        private readonly UserService _userService;
        private readonly ProjectService _projectService;

        public ProjectController(ServiceCompanyDbContext dbContext, UserService userService, ProjectService projectService)
        {
            _dbContext = dbContext;
            _userService = userService;
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectModel>> GetAsync()
        {
            return await _dbContext.Projects.Select(p => p.ToDto()).ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = _projectService.Get(id);

            return project != null ? Ok(project) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] ProjectModel model)
        {
            if (model != null)
            {
                var user = _userService.GetUser(HttpContext.User.Identity.Name);

                if(user != null)
                {
                    var admin = _dbContext.Admins.SingleOrDefault(a =>a.Id == user.Id);

                    if(admin == null)
                    {
                        admin = new Admin(user);
                        _dbContext.Admins.Add(admin);
                    }
                    model.AdminId = admin.Id;
                }

                var result = _projectService.Create(model);

                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPost("add/all")]
        public async Task<IActionResult> CreateMultipleAsync([FromBody] List<ProjectModel> model)
        {
            if (model != null && model.Count > 0)
            {
                var result = _projectService.CreateMultipleUsersAsync(model);
                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpPatch("update/{id}")]
        public IActionResult Update(int id, [FromBody] ProjectModel model)
        {
            if (model != null)
            {
                var result = _projectService.Update(id, model);

                return result ? Ok() : NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}
