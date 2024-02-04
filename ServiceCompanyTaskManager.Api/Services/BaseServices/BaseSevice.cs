namespace ServiceCompanyTaskManager.Api.Services.BaseServices
{
    public abstract class BaseSevice 
    {
        public bool UserAction(Action action)
        {
            try
            {
                action.Invoke();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
