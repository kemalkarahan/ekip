using System;
using System.Collections.Generic;
using System.Linq;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private readonly IMemberDal memberDal;
        private readonly IStreamService streamService;
        private readonly IPermissionService permissionService;
        public MemberManager(IMemberDal memberDal, IStreamService streamService, IPermissionService permissionService)
        {
            this.memberDal = memberDal;
            this.streamService = streamService;
            this.permissionService = permissionService;
        }
        public async Task<IResult> DeleteAsync(Member entity, int operatorId)
        {
            
            try
            {
                var result = await RetrieveByIdAsync(operatorId);

                if (result.Success)
                {
                    if (await permissionService.CheckRemovePersonnelPermissionAsync(entity.StreamId, result.Data.Role))
                    {
                        if (!(await streamService.CheckIsMemberOwver(entity.StreamId, entity.StaffId)))
                        {
                            await memberDal.Delete(entity);
                            return new SuccessResult(InfoMessages.Deleted);
                        }
                    }
                }
                
                return new ErrorResult("üye silmek için yetkiniz bulunmamaktadır.");
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Member entity, int operatorId)
        {
            try
            {
                var result = await RetrieveByIdAsync(operatorId);

                if (result.Success)
                {
                    if (await permissionService.CheckAddPersonnelPermissionAsync(entity.StreamId, result.Data.Role))
                    {
                        await memberDal.Insert(entity);
                        return new SuccessResult(InfoMessages.Added);
                    }
                }

                return new ErrorResult("Üye eklemek için yetkiniz bulunmamaktadır.");
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Member>> RetrieveByIdAsync(int memberId)
        {
            try
            {
                return new SuccessDataResult<Member>(await memberDal.RetrieveWithStaffInfo(m => m.Id == memberId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Member>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Member>>> RetrieceAllAsync(int institutionId)
        {
            try
            {
                var list = await memberDal.RetrieveAlWithStaffInfo(m => m.Id == institutionId);
                return new SuccessDataResult<List<Member>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Member>>(InfoMessages.Error);
            }
        }
    }
}
