using ServiceCompanyTaskManager.Common.Models.Entities;
using ServiceCompanyTaskManager.Common.Models.Enums;

namespace ServiceCompanyTaskManager.Common.Models
{
    public class UserModel : IEntity
    {
        public int Id { get; set; }

        public Guid UUID { get; set; } = Guid.NewGuid();

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string ShortName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public byte[]? Avatar { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public Permission Permission { get; set; }

        public Status Status { get; set; }
        public string? Description { get; set; }

        public UserModel()
        {

        }

        public UserModel(string shortName, string email, string password, string? firstname, string? lastName,
            Permission permission, Status status, string phoneNumber)
        {
            FirstName = firstname;
            LastName = lastName;
            ShortName = shortName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Permission = permission;
            Status = status;
            RegistrationDate = DateTime.Now;
        }
    }
}
