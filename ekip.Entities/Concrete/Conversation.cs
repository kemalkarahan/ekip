using System;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Conversation : IEntity
    {
        public int Id { get; set; }
        public int HolderId { get; set; }
        public virtual Staff Holder { get; set; }
        public int WithId { get; set; }
        public virtual Staff With { get; set; }
        public string Topic { get; set; }
        public DateTime SentDate { get; set; }
    }
}
