using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IParticipantService
    {
        Task<IResult> InsertAsync(Participant entity);
        Task<IResult> DeleteAsync(Participant entity);
        Task<IResult> UpdateAsync(Participant entity);
        Task<bool> CheckParticipantExistInListAsync(int participantId, int eventId);
    }
}
