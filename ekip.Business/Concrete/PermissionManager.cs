using System;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class PermissionManager : IPermissionService
    {
        private IPermissionDal permissionDal;
        public PermissionManager(IPermissionDal permissionDal)
        {
            this.permissionDal = permissionDal;
        }
        public async Task<IResult> DeleteAsync(Permission entity)
        {
            try
            {
                await permissionDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Permission entity)
        {
            try
            {
                await permissionDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Permission entity)
        {
            try
            {
                await permissionDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckAddPersonnelPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckAddPersonnelPermission(streamId, role);
        }

        public async Task<bool> CheckRemovePersonnelPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckRemovePersonnelPermission(streamId, role);
        }

        public async Task<bool> CheckEditAboutPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckEditAboutPermission(streamId, role);
        }

        public async Task<bool> CheckEditIconPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckEditIconPermission(streamId, role);
        }

        public async Task<bool> CheckEditLabelPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckEditLabelPermission(streamId, role);
        }

        public async Task<bool> CheckShareStreamPermissionAsync(int streamId, EnumCollection.Roles role)
        {
            return await permissionDal.CheckShareStreamPermission(streamId, role);
        }
    }
}
