using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IPermissionService
    {
        Task<IResult> InsertAsync(Permission entity);
        Task<IResult> DeleteAsync(Permission entity);
        Task<IResult> UpdateAsync(Permission entity);
        Task<bool> CheckAddPersonnelPermissionAsync(int streamId, EnumCollection.Roles role);
        Task<bool> CheckRemovePersonnelPermissionAsync(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditAboutPermissionAsync(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditIconPermissionAsync(int streamId, EnumCollection.Roles role);
        Task<bool> CheckEditLabelPermissionAsync(int streamId, EnumCollection.Roles role);
        Task<bool> CheckShareStreamPermissionAsync(int streamId, EnumCollection.Roles role);
    }
}
