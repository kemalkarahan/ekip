using System.Collections.Generic;

namespace ekip.Entities.Concrete
{
    public class Notification : Preference
    {
        public Notification()
        {
            Schedules = new List<Schedule>();
        }
        public bool IsPreviewEnabled { get; set; }
        public bool IsSoundEnabled { get; set; }
        public bool AboutNewMessage { get; set; }
        public bool AboutConversation { get; set; }
        public bool AboutMention { get; set; }
        public bool AboutThread { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
