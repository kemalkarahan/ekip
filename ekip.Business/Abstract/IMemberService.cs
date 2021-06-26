using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IMemberService
    {
        Task<IResult> InsertAsync(Member entity, int operatorId);
        Task<IResult> DeleteAsync(Member entity, int operatorId);
        Task<IDataResult<Member>> RetrieveByIdAsync(int memberId);
        Task<IDataResult<List<Member>>> RetrieceAllAsync(int institutionId);
    }
}
