using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IStreamService
    {
        Task<IResult> InsertAsync(Stream entity);
        Task<IResult> DeleteAsync(Stream entity);
        Task<IResult> UpdateAsync(Stream entity);
        Task<IDataResult<Stream>> RetrieveStreamByIdAsync(int streamId);
        Task<IDataResult<List<Stream>>> RetrieveAllAsync(int institutionId);
        Task<bool> CheckIsMemberOwver(int streamId, int memberId);
    }
}
