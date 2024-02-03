using ServiceCompanyTaskManager.Api.Models.BaseModels;
using ServiceCompanyTaskManager.Common.Models;
using ServiceCompanyTaskManager.Common.Models.Enums;
using System.Security;

namespace ServiceCompanyTaskManager.Api.Models
{
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public Permission Permission { get; set; }

        public Status Status { get; set; }

        public virtual List<Project>? Projects { get; set; } = new List<Project>();

        public virtual List<Desk>? Desks { get; set; } = new List<Desk>();

        public virtual List<ProjectTask>? UserCreatedTasks { get; set; } = new List<ProjectTask>();

        public virtual List<ProjectTask>? UserExecutedTasks { get; set; } = new List<ProjectTask>();

        public User()
        {

        }

        public User(string shortName, string email, string password, string? firstname = null, string? lastName = null,
            Permission permission = Permission.User, Status status = Status.Active, byte[]? avatar = null, string? phoneNumber = null)
        {
            FirstName = firstname;
            LastName = lastName;
            ShortName = shortName;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Permission = permission;
            Status = status;
            RegistrationDate = DateTime.Now;
        }

        public User(UserModel userModel)
        {
            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            ShortName = userModel.ShortName;
            Email = userModel.Email;
            Password = userModel.Password;
            PhoneNumber = userModel.PhoneNumber;
            Avatar = userModel.Avatar;
            Permission = userModel.Permission;
            Status = userModel.Status;
            RegistrationDate = userModel.RegistrationDate;
        }

        public UserModel ToDto()
        {
            return new UserModel()
            {
                Id = this.Id,
                UUID = this.UUID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                ShortName = this.ShortName,
                Email = this.Email,
                Password = this.Password,
                PhoneNumber = this.PhoneNumber,
                Avatar = this.Avatar,
                Permission = this.Permission,
                Status = this.Status,
                RegistrationDate = this.RegistrationDate
            };
        }
    }
}
