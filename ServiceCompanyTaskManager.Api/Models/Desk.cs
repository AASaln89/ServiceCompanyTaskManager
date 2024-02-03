using ServiceCompanyTaskManager.Api.Models.BaseModels;
using ServiceCompanyTaskManager.Common.Models.Entities;

namespace ServiceCompanyTaskManager.Api.Models
{
    public class Desk : BaseEntity, IEntity
    {
        public string Adress { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsPrivate { get; set; }

        public string Columns { get; set; }

        public virtual Admin? DeskAuthor { get; set; }

        public virtual Project? Project { get; set; }

        public virtual List<User>? Users { get; set; } = new List<User>();

        public virtual List<ProjectTask>? Tasks { get; set; } = new List<ProjectTask>();
    }
}