using Microsoft.AspNetCore.Mvc;
using ServiceCompanyTaskManager.Api.DbContexts;
using ServiceCompanyTaskManager.Api.Models;
using ServiceCompanyTaskManager.Api.Services.BaseServices;
using ServiceCompanyTaskManager.Common.Models;
using ServiceCompanyTaskManager.Common.Models.Enums;
using System.Security.Claims;
using System.Text;

namespace ServiceCompanyTaskManager.Api.Services
{
    public class UserService : IBaseService<UserModel>
    {
        private readonly ServiceCompanyDbContext _dbContext;

        public UserService(ServiceCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(string login, string password)
        {
            return _dbContext.Users.SingleOrDefault(u =>u.Email == login && u.Password == password);
        }

        public Tuple<string, string> GetLoginPassByBaseAuth(HttpRequest request)
        {
            string login = string.Empty;
            string password = string.Empty;
            string authHeader = request.Headers["Authorization"].ToString();
            
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                string encocdedLogInfo = authHeader.Replace("Basic", "");
                var encoding = Encoding.GetEncoding("iso-8859-1");

                string[] loginPass = encoding.GetString(Convert.FromBase64String(encocdedLogInfo)).Split(":");

                login = loginPass[0];
                password = loginPass[1];
            }

            return Tuple.Create(login, password);
        }

        public ClaimsIdentity GetIdentity(string login, string password)
        {
            var currentUser = GetUser(login, password);

            if (currentUser != null)
            {
                currentUser.LastLoginDate = DateTime.Now;

                _dbContext.SaveChanges();

                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, currentUser.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, currentUser.Permission.ToString())
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }

        public void Create(UserModel userModel)
        {
            var user = new User(userModel.ShortName, userModel.Email, userModel.Password,
                    userModel.FirstName, userModel.LastName, Permission.SuperAdmin,
                    Status.Active, userModel.Avatar, userModel.PhoneNumber);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public void Update(int id, UserModel userModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Avatar = userModel.Avatar;
                user.PhoneNumber = userModel.PhoneNumber;
                user.Email = userModel.Email;
                user.Status = userModel.Status;
                user.Password = userModel.Password;
                user.Permission = userModel.Permission;
                user.Description = userModel.Description;
                user.ExpireDate = userModel.ExpireDate;
                user.ShortName = userModel.ShortName;

                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);

                _dbContext.SaveChanges();
            }
        }

        public void AddMultipleUsersAsync(List<UserModel> userModels)
        {
            if (userModels != null && userModels.Count > 0)
            {
                var users = userModels.Select(um => new User(um)).ToList();

                _dbContext.Users.AddRange(users);

                _dbContext.SaveChangesAsync();
            }
        }
    }
}
