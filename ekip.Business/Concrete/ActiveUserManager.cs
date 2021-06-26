using ekip.Business.Abstract;
using ekip.Entities.DomainModels;
using System.Collections.Generic;
using System.Linq;

namespace ekip.Business.Concrete
{
    public class ActiveUserManager : IActiveUserService
    {
        public void AddToActiveUserList(ActiveUsers activeUser, CurrentUser currentUser)
        {
            bool isUserExist = activeUser.ActiveUserList.Any(a => a.InstitutionId == currentUser.InstitutionId && a.UserId == currentUser.UserId);

            if (!isUserExist)
            {
                activeUser.ActiveUserList.Add(currentUser);
            }
            return;
        }

        public List<CurrentUser> GetActiveUsers(ActiveUsers activeUser, int institutionId)
        {
            return activeUser.ActiveUserList.Where(a => a.InstitutionId == institutionId).ToList();
        }

        public void RemoveFromActiveUserList(ActiveUsers activeUser, CurrentUser currentUser)
        {
            bool isUserExist = activeUser.ActiveUserList.Any(a => a.InstitutionId == currentUser.InstitutionId && a.UserId == currentUser.UserId);

            if (isUserExist)
            {
                activeUser.ActiveUserList.Remove(currentUser);
            }
            return;
        }
    }
}
