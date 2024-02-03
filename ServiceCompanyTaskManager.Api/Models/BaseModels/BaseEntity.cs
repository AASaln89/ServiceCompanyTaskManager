using ServiceCompanyTaskManager.Common.Models.Entities;

namespace ServiceCompanyTaskManager.Api.Models.BaseModels
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }

        public Guid UUID { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }

        public string ShortName { get; set; }

        public string? Description { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public byte[]? Avatar { get; set; }

        public BaseEntity()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
