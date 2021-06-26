using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Preference : IEntity
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
