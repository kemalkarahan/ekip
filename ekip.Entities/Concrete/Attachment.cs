using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Attachment : IEntity
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }
        public string Location { get; set; }
        public string Label { get; set; }
    }
}
