using System.Collections.Generic;
using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Stream : IEntity
    {
        public Stream()
        {
            Members = new List<Member>();
            Messages = new List<Message>();
            Permissions = new List<Permission>
            {
                new Permission
                {
                    Role = EnumCollection.Roles.Manager,
                    AddPersonnel = true,
                    EditAbout = true,
                    EditIcon = true,
                    EditLabel = true,
                    RemovePersonnel = true,
                    ShareStream = true
                },
                new Permission
                {
                    Role = EnumCollection.Roles.Member,
                    AddPersonnel = false,
                    EditAbout = false,
                    EditIcon = false,
                    EditLabel = false,
                    RemovePersonnel = false,
                    ShareStream = false
                }
            };
        }
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public List<Member> Members { get; set; }
        public List<Message> Messages { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
