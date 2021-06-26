using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IMessageService
    {
        Task<IResult> InsertAsync(Message entity);
        Task<IResult> DeleteAsync(Message entity);
        Task<IResult> UpdateAsync(Message entity);
        Task<IDataResult<Message>> RetrieveByIdAsync(int messageId);
        Task<IDataResult<List<Message>>> RetrieveAllAsync(int streamId);
    }
}
