using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Participant : IEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int AttendeeId { get; set; }
        public virtual User Attendee { get; set; }
    }
}
