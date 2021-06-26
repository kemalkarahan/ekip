using ekip.Entities.DomainModels;
using ekip.UI.Web.MVC.Extensions;
using ekip.UI.Web.MVC.Helpers.Abstract;
using Microsoft.AspNetCore.Http;

namespace ekip.UI.Web.MVC.Helpers.Concrete
{
    public class ActiveUserSessionHelper : IActiveUserSessionHelper
    {
        private IHttpContextAccessor httpContextAccessor;
        public ActiveUserSessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Clear()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public ActiveUsers GetActiveUsers(string key)
        {
            ActiveUsers activeUsers = httpContextAccessor.HttpContext.Session.GetObject<ActiveUsers>(key);
            if (activeUsers == null)
            {
                SetActiveUsers(key, new ActiveUsers());
                activeUsers = httpContextAccessor.HttpContext.Session.GetObject<ActiveUsers>(key);
            }

            return activeUsers;
        }

        public void SetActiveUsers(string key, ActiveUsers activeUsers)
        {
            httpContextAccessor.HttpContext.Session.SetObject(key, activeUsers);
        }
    }
}
