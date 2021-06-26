using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfStreamDal : EfEntityRepositoryBase<Stream, EkipContext>, IStreamDal
    {
    }
}
