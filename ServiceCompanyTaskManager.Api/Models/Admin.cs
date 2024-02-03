using ServiceCompanyTaskManager.Api.Models.BaseModels;

namespace ServiceCompanyTaskManager.Api.Models
{
    public class Admin : User
    {
        private User _user;

        public Admin()
        {

        }

        public Admin(User user)
        {
            _user = user;
        }
    }
}
