using ServiceCompanyTaskManager.Api.Models.BaseModels;
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
    }
}
