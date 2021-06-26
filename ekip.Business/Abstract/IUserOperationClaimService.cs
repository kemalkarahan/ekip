using System.Threading.Tasks;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        Task<IResult> InsertAsync(UserOperationClaim entity);
        Task<IResult> UpdateAsync(UserOperationClaim entity);
        Task<IResult> DeleteAsync(UserOperationClaim entity);
    }
}
