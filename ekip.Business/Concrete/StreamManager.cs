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
    public class StreamManager : IStreamService
    {
        private IStreamDal streamDal;
        public StreamManager(IStreamDal streamDal)
        {
            this.streamDal = streamDal;
        }
        public async Task<IResult> DeleteAsync(Stream entity)
        {
            try
            {
                await streamDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Stream entity)
        {
            try
            {
                await streamDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Stream entity)
        {
            try
            {
                await streamDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Stream>> RetrieveStreamByIdAsync(int streamId)
        {
            try
            {
                return new SuccessDataResult<Stream>(await streamDal.Retrieve(s => s.Id == streamId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Stream>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Stream>>> RetrieveAllAsync(int institutionId)
        {
            try
            {
                var list = await streamDal.RetrieveAll(s => s.InstitutionId == institutionId);
                return new SuccessDataResult<List<Stream>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Stream>>(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckIsMemberOwver(int streamId, int memberId)
        {
            return await streamDal.Check(s => s.Id == streamId && s.StaffId == memberId);
        }
    }
}
