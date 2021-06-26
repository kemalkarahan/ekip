using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfBoardDal : EfEntityRepositoryBase<Board, EkipContext>, IBoardDal
    {
        
        public async Task<Board> RetrieveWithContexts(Expression<Func<Board, bool>> filter)
        {
            using (var context = new EkipContext())
            {
                return await context.Set<Board>().Include(b => b.BoardContexts).Include(b => b.Followers).SingleOrDefaultAsync(filter);
            }
        }
    }
}
