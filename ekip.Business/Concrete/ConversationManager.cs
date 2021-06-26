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
    public class ConversationManager : IConversationService
    {
        private IConversationDal conversationDal;
        public ConversationManager(IConversationDal conversationDal)
        {
            this.conversationDal = conversationDal;
        }
        public async Task<IResult> DeleteAsync(Conversation entity)
        {
            try
            {
                await conversationDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Conversation entity)
        {
            try
            {
                await conversationDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }
        
        public async Task<IDataResult<List<Conversation>>> RetrieveAllWithPeopleAsync(int holderId, int withId)
        {
            try
            {
                var list = await conversationDal.RetrieveAllWithPeople(c => c.HolderId == holderId && c.WithId == withId);
                return new SuccessDataResult<List<Conversation>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Conversation>>(InfoMessages.Error);
            }
        }
    }
}
