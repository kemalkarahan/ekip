using System.Collections.Generic;
using System.Threading.Tasks;
using ekip.Core.DataAccess.Concrete.EntityFramework;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using ekip.MySQL.EntityFramework;

namespace ekip.DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : EfEntityRepositoryBase<Event, EkipContext>, IEventDal
    {
        private IParticipantDal participantDal;
        public EfEventDal(IParticipantDal participantDal)
        {
            this.participantDal = participantDal;
        }

        public async Task<IList<Participant>> RetrieveParticipants(int eventId)
        {
            return await participantDal.RetrieveAll(p => p.EventId == eventId);
        }
    }
}
