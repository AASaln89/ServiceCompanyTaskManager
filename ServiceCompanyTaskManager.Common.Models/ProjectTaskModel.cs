namespace ServiceCompanyTaskManager.Common.Models
{
    public class ProjectTaskModel : BaseEntityModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte[] File { get; set; }

        public string Column { get; set; }

        public int ExecutorId { get; set; }

        public int AuthorId { get; set; }

        public int DeskId { get; set; }
    }
}