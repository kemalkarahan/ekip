using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IBoardService
    {
        Task<IResult> InsertAsync(Board entity);
        Task<IResult> DeleteAsync(Board entity);
        Task<IResult> UpdateAsync(Board entity);
        Task<IDataResult<Board>> RetrieveByIdAsync(int id);
        Task<IDataResult<List<Board>>> RetrieveAllByInstitutionIdAsync(int institutionId, int followerId);
    }
}
