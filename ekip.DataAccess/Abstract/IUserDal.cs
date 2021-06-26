using System.Collections.Generic;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<IList<OperationClaim>> RetrieveClaims(User user);
    }
}
