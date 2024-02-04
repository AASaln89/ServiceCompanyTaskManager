using ServiceCompanyTaskManager.Api.Models.BaseModels;
using ServiceCompanyTaskManager.Common.Models;
using ServiceCompanyTaskManager.Common.Models.Enums;

namespace ServiceCompanyTaskManager.Api.Models
{
    public class Project : BaseEntity
    {
        public string Adress { get; set; }

        public Status Status { get; set; }

        public DateTime ExpireDate { get; set; }

        //public virtual MemberStatus? Status { get; set; }

        //public virtual Company? Company { get; set; }

        public virtual Admin? Admin { get; set; }

        public virtual List<User>? Executors { get; set; } = new List<User>();

        public virtual List<Desk>? Desks { get; set; } = new List<Desk>();

        public Project() { }

        public Project(ProjectModel model) : base(model)
        {
            Adress = model.Adress;
            Status = model.Status;
            ExpireDate = model.ExpireDate;
            Admin.Id = model.AdminId;
        }

        public ProjectModel ToDto()
        {
            return new ProjectModel()
            {
                Id = this.Id,
                UUID = this.UUID,
                Name = this.Name,
                ShortName = this.ShortName,
                Avatar = this.Avatar,
                RegistrationDate = this.RegistrationDate,
                Description = this.Description,
                Status = this.Status,
                Adress = this.Adress,
                ExpireDate = this.ExpireDate,
                AdminId = this.Admin.Id,
            };
        }
    }
}
