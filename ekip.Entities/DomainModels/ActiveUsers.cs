using ekip.Core.Entities.Abstract;
using System.Collections.Generic;

namespace ekip.Entities.DomainModels
{
    public class ActiveUsers : IDomainModel
    {
        public ActiveUsers()
        {
            ActiveUserList = new List<CurrentUser>();
        }
        public List<CurrentUser> ActiveUserList { get; set; }
    }
}
