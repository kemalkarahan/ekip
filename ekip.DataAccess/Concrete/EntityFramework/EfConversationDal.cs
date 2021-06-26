using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfConversationDal : EfEntityRepositoryBase<Conversation, EkipContext>, IConversationDal
    {
        
        public async Task<IList<Conversation>> RetrieveAllWithPeople(Expression<Func<Conversation, bool>> filter)
        {
            using (var context = new EkipContext())
            {
                return filter != null ? await context.Set<Conversation>().Where(filter).Include(c => c.With).Include(c => c.Holder).ToListAsync()
                    : await context.Set<Conversation>().Include(c => c.With).Include(c => c.Holder).ToListAsync();
            }
        }
    }
}
