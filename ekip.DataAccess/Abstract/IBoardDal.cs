using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IBoardDal : IEntityRepository<Board>
    {
        Task<Board> RetrieveWithContexts(Expression<Func<Board, bool>> filter);
    }
}
