using ekip.Entities.DomainModels;

namespace ekip.UI.Web.MVC.Helpers.Abstract
{
    public interface IActiveUserSessionHelper
    {
        ActiveUsers GetActiveUsers(string key);
        void SetActiveUsers(string key, ActiveUsers activeUsers);
        void Clear();
    }
}
