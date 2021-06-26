using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        public int StreamId { get; set; }
        public virtual Stream Stream { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public EnumCollection.Roles Role { get; set; }
    }
}
