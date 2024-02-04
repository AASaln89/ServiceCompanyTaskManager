using ServiceCompanyTaskManager.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCompanyTaskManager.Common.Models
{
    public class BaseEntityModel : IEntity
    {
        public int Id { get; set; }

        public Guid UUID { get; set; } = Guid.NewGuid();

        public string? Name { get; set; }

        public string ShortName { get; set; }

        public string? Description { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public byte[]? Avatar { get; set; }
    }
}
