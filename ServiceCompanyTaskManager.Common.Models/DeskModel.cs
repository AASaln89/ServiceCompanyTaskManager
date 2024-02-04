namespace ServiceCompanyTaskManager.Common.Models
{
    public class DeskModel : BaseEntityModel
    {
        public string Adress { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsPrivate { get; set; }

        public string[] Columns { get; set; }

        public int DeskAuthorId { get; set; }

        public int ProjectId { get; set; }

        public List<UserModel>? Users { get; set; } = new List<UserModel>();

        public List<ProjectTaskModel>? Tasks { get; set; } = new List<ProjectTaskModel>();
    }
}