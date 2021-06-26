using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Permission : IEntity
    {
        public int Id { get; set; }
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public EnumCollection.Roles Role { get; set; }
        public bool AddPersonnel { get; set; }
        public bool RemovePersonnel { get; set; }
        public bool EditAbout { get; set; }
        public bool EditIcon { get; set; }
        public bool EditLabel { get; set; }
        public bool ShareStream { get; set; }
    }
}
