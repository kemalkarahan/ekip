using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.Core.Entities.Concrete;
using ekip.DataAccess.Abstract;
using ekip.MySQL.EntityFramework;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, EkipContext>, IUserOperationClaimDal
    {
    }
}
