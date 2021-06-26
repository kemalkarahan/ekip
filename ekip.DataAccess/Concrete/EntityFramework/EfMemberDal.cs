using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, EkipContext>, IMemberDal
    {
        public async Task<Member> RetrieveWithStaffInfo(Expression<Func<Member, bool>> filter)
        {
            using (var context = new EkipContext())
            {
                return await context.Set<Member>().Include(m => m.Staff).SingleOrDefaultAsync(filter);
            }
        }

        public async Task<IList<Member>> RetrieveAlWithStaffInfo(Expression<Func<Member, bool>> filter)
        {
            using (var context = new EkipContext())
            {
                return filter != null ? await context.Set<Member>().Where(filter).Include(m => m.Staff).ToListAsync() : await context.Set<Member>().ToListAsync();
            }
        }
    }
}
