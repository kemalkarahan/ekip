using System;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
        public bool IsAllowed { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
