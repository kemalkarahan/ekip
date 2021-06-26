using System.Collections.Generic;
using System.Linq;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;
using Exception = System.Exception;

namespace ekip.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }
        public async Task<IResult> DeleteAsync(Message entity)
        {
            try
            {
                await messageDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Message entity)
        {
            try
            {
                await messageDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Message entity)
        {
            try
            {
                await messageDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Message>> RetrieveByIdAsync(int messageId)
        {
            try
            {
                return new SuccessDataResult<Message>(await messageDal.Retrieve(m => m.Id == messageId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Message>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Message>>> RetrieveAllAsync(int streamId)
        {
            try
            {
                var list = await messageDal.RetrieveAll(m => m.StreamId == streamId);
                return new SuccessDataResult<List<Message>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Message>>(InfoMessages.Error);
            }
        }
    }
}
