using ServiceCompanyTaskManager.Common.Models;
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

        public BaseEntity(BaseEntityModel model)
        {
            Id = model.Id;

            UUID = model.UUID;

            Name = model.Name;

            ShortName = model.ShortName;

            Description = model.Description;

            RegistrationDate = model.RegistrationDate;

            Avatar = model.Avatar;
        }
    }
}
