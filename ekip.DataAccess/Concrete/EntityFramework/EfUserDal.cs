using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.Core.Entities.Concrete;
using ekip.DataAccess.Abstract;
using ekip.MySQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EkipContext>, IUserDal
    {
        public async Task<IList<OperationClaim>> RetrieveClaims(User user)
        {
            using (var context = new EkipContext())
            {
                IList<UserOperationClaim> list =  user != null
                    ? await context.Set<UserOperationClaim>().Where(u => u.UserId == user.Id)
                        .Include(u => u.OperationClaim).ToListAsync()
                    : await context.Set<UserOperationClaim>().Include(u => u.OperationClaim).ToListAsync();
                return list.Select(o => o.OperationClaim).ToList();
            }
        }
    }
}
