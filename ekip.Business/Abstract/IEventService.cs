using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IEventService
    {
        Task<IResult> InsertAsync(Event entity);
        Task<IResult> DeleteAsync(Event entity);
        Task<IResult> UpdateAsync(Event entity);
        Task<IDataResult<Event>> RetrieveByIdAsync(int eventId);
        Task<IDataResult<List<Participant>>> RetrieveParticipantsAsync(int eventId);
        Task<bool> CheckParticipantExistInListAsync(int participantId, int eventId);
    }
}
