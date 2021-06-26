using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IConversationService
    {
        Task<IResult> InsertAsync(Conversation entity);
        Task<IResult> DeleteAsync(Conversation entity);
        Task<IDataResult<List<Conversation>>> RetrieveAllWithPeopleAsync(int holderId, int withId);
    }
}
