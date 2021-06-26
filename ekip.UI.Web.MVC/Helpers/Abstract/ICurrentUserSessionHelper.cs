using ekip.Entities.DomainModels;

namespace ekip.UI.Web.MVC.Helpers.Abstract
{
    public interface ICurrentUserSessionHelper
    {
        CurrentUser GetCurrentUser(string key);
        void SetCurrentUser(string key, CurrentUser activeUsers);
        void Clear();
    }
}
