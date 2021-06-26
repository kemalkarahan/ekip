using System;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class BoardContext : IEntity
    {
        public int Id { get; set; }
        public int WriterId { get; set; }
        public virtual Staff Writer { get; set; }
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
