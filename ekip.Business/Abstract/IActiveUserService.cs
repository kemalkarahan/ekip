using ekip.Entities.DomainModels;
using System.Collections.Generic;

namespace ekip.Business.Abstract
{
    public interface IActiveUserService
    {
        void AddToActiveUserList(ActiveUsers activeUser, CurrentUser currentUser);
        void RemoveFromActiveUserList(ActiveUsers activeUser, CurrentUser currentUser);
        List<CurrentUser> GetActiveUsers(ActiveUsers activeUser, int institutionId);
    }
}
