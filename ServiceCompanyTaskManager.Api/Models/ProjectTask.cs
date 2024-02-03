using ServiceCompanyTaskManager.Api.Models.BaseModels;

namespace ServiceCompanyTaskManager.Api.Models
{
    public class ProjectTask : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public byte[] File { get; set; }

        public string Column { get; set; }

        public virtual User? Executor { get; set; }

        public virtual User? Author { get; set; }

        public virtual Desk? Desk { get; set; }
    }
}
