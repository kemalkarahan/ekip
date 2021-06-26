using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IAttachmentService
    {
        Task<IResult> InsertAsync(Attachment entity);
        Task<IResult> DeleteAsync(Attachment entity);
        Task<IResult> UpdateAsync(Attachment entity);
        Task<IDataResult<Attachment>> RetrieveByIdAsync(int id);
    }
}
