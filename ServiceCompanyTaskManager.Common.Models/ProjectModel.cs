using ServiceCompanyTaskManager.Common.Models.Enums;

namespace ServiceCompanyTaskManager.Common.Models
{
    public class ProjectModel : BaseEntityModel
    {
        public string Adress { get; set; }

        public Status Status { get; set; }

        public DateTime ExpireDate { get; set; }

        public int AdminId { get; set; }

        public List<UserModel>? Executors { get; set; } = new List<UserModel>();

        public List<DeskModel>? Desks { get; set; } = new List<DeskModel>();
    }
}