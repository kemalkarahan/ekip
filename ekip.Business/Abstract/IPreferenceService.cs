using System.Collections.Generic;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;
using ekip.Entities.Concrete;

namespace ekip.Business.Abstract
{
    public interface IPreferenceService
    {
        Task<IResult> InsertAsync(Preference entity);
        Task<IResult> UpdateAsync(Preference entity);
        Task<IResult> DeleteAsync(Preference entity);
        Task<IDataResult<Preference>> RetrieveByIdAsync(int preferenceId);
        Task<IDataResult<List<Preference>>> RetrieveAllAsyns(int staffId);
    }
}
