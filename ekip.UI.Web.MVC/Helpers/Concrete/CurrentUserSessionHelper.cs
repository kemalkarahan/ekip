using ekip.Entities.DomainModels;
using ekip.UI.Web.MVC.Extensions;
using ekip.UI.Web.MVC.Helpers.Abstract;
using Microsoft.AspNetCore.Http;

namespace ekip.UI.Web.MVC.Helpers.Concrete
{
    public class CurrentUserSessionHelper : ICurrentUserSessionHelper
    {
        private IHttpContextAccessor httpContextAccessor;
        public CurrentUserSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Clear()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public CurrentUser GetCurrentUser(string key)
        {
            CurrentUser activeUsers = httpContextAccessor.HttpContext.Session.GetObject<CurrentUser>(key);
            if (activeUsers == null)
            {
                SetCurrentUser(key, new CurrentUser());
                activeUsers = httpContextAccessor.HttpContext.Session.GetObject<CurrentUser>(key);
            }

            return activeUsers;
        }

        public void SetCurrentUser(string key, CurrentUser currentUser)
        {
            httpContextAccessor.HttpContext.Session.SetObject(key, currentUser);
        }
    }
}
