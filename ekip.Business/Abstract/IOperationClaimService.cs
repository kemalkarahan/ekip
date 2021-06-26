using System.Threading.Tasks;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IResult> InsertAsync(OperationClaim entity);
        Task<IResult> UpdateAsync(OperationClaim entity);
        Task<IResult> DeleteAsync(OperationClaim entity);
    }
}
