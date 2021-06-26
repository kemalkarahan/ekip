using ekip.Core.Entities.Concrete;
using ekip.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ekip.MySQL.EntityFramework
{
    public class EkipContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=ekip;user=kk;password=karahanll09");
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardContext> BoardContexts { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
