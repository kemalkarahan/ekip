using System.Collections.Generic;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        Task<IList<Participant>> RetrieveParticipants(int eventId);
    }
}
