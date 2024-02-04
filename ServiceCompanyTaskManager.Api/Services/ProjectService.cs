using ServiceCompanyTaskManager.Api.DbContexts;
using ServiceCompanyTaskManager.Api.Models;
using ServiceCompanyTaskManager.Api.Services.BaseServices;
using ServiceCompanyTaskManager.Common.Models;

namespace ServiceCompanyTaskManager.Api.Services
{
    public class ProjectService : BaseSevice, IBaseService<ProjectModel>
    {
        private readonly ServiceCompanyDbContext _dbContext;

        public ProjectService(ServiceCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectModel Get(int id) 
        {
            return _dbContext.Projects?.SingleOrDefault(p => p.Id == id)?.ToDto();
        }

        public bool Create(ProjectModel model)
        {
            return UserAction(delegate ()
            {
                var project = new Project(model);

                _dbContext.Projects.Add(project);

                _dbContext.SaveChanges();
            });
        }

        public bool Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            if (project != null)
            {
                return UserAction(delegate ()
                {
                    _dbContext.Projects.Remove(project);

                    _dbContext.SaveChanges();

                    _dbContext.SaveChangesAsync();
                });
            }
            return false;
        }

        public bool Update(int id, ProjectModel model)
        {
            var project = _dbContext.Projects.SingleOrDefault(u => u.Id == id);

            if (project != null)
            {
                return UserAction(delegate ()
                {
                    project.Name = model.Name;
                    project.Avatar = model.Avatar;
                    project.Adress = model.Adress;
                    project.Avatar = model.Avatar;
                    project.Status = model.Status;
                    project.ExpireDate = model.ExpireDate;
                    project.Status = model.Status;
                    project.Admin.Id = model.AdminId;
                    project.Description = model.Description;
                    project.ExpireDate = model.ExpireDate;
                    project.ShortName = model.ShortName;

                    _dbContext.SaveChanges();
                });
            }
            return false;
        }
    }
}
