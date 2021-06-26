namespace ekip.Entities.Concrete
{
    public class Follower
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
