using System;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class AttachmentManager : IAttachmentService
    {
        private IAttachmentDal attachmentDal;
        public AttachmentManager(IAttachmentDal attachmentDal)
        {
            this.attachmentDal = attachmentDal;
        }

        public async Task<IResult> DeleteAsync(Attachment entity)
        {
            try
            {
                await attachmentDal.Delete(entity);

                return new SuccessResult(InfoMessages.Deleted);

            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Attachment entity)
        {
            try
            {
                await attachmentDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Attachment entity)
        {
            try
            {
                await attachmentDal.Update(entity);

                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Attachment>> RetrieveByIdAsync(int id)
        {
            try
            {
                return new SuccessDataResult<Attachment>(await attachmentDal.Retrieve(a => a.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Attachment>(InfoMessages.Error);
            }
        }
    }
}
