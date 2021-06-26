using System.Collections.Generic;
using System.Threading.Tasks;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> InsertAsync(User entity);
        Task<IResult> DeleteAsync(User entity);
        Task<IResult> UpdateAsync(User entity);
        Task<IDataResult<User>> RetrieveByIdAsync(int userId);
        Task<IDataResult<User>> RetrieveByEmailAsync(string email);
        Task<IDataResult<List<OperationClaim>>> RetrieveClaimsAsync(User user);
        Task<bool> CheckUserExistsAsync(string email);
    }
}
