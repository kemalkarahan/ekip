using System;
using System.Linq.Expressions;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IInstitutionService
    {
        Task<IResult> InsertAsync(Institution entity);
        Task<IResult> DeleteAsync(Institution entity);
        Task<IResult> UpdateAsync(Institution entity);
        Task<IDataResult<Institution>> RetrieveByIdAsync(int institutionId);
        Task<IDataResult<Institution>> RetrieveByCodeAsync(int institutionCode);
        Task<bool> CheckAsync(Expression<Func<Institution, bool>> filter);
    }
}
