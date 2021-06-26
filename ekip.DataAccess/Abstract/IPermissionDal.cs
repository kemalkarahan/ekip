using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Core.Entities.Concrete;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IPermissionDal : IEntityRepository<Permission>
    {
        Task<bool> CheckAddPersonnelPermission(int streamId, EnumCollection.Roles role);
        Task<bool> CheckRemovePersonnelPermission(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditAboutPermission(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditIconPermission(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditLabelPermission(int streamId, EnumCollection.Roles role);
        Task<bool> CheckShareStreamPermission(int streamId, EnumCollection.Roles role);
    }
}
