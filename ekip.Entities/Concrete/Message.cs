using System;
using System.Collections.Generic;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public int SenderId { get; set; }
        public Staff Sender { get; set; }
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public virtual List<Attachment> Attachments { get; set; }
    }
}
