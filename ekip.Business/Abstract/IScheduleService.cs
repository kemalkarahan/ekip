using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IScheduleService
    {
        Task<IResult> InsertAsync(Schedule entity);
        Task<IResult> DeleteAsync(Schedule entity);
        Task<IResult> UpdateAsync(Schedule entity);
    }
}
