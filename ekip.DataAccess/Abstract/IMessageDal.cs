using ekip.Core.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
    }
}
