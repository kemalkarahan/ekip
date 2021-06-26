using System;
using System.Collections.Generic;
using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Event : IEntity
    {
        public Event()
        {
            Participants = new List<Participant>();
        }
        public int Id { get; set; }
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public int OrganizerId { get; set; }
        public virtual Staff Organizer { get; set; }
        public EnumCollection.EventTypes EventType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Reminder { get; set; }
        public DateTime BegunDate { get; set; }
        public DateTime EndedDate { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
