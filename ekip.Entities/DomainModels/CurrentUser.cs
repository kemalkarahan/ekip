using ekip.Core.Entities.Abstract;
using ekip.Core.Entities.Concrete;
using ekip.Entities.Concrete;

namespace ekip.Entities.DomainModels
{
    public class CurrentUser : IDomainModel
    {
        public int UserId { get; set; }
        public int InstitutionId { get; set; }
        public string DisplayName { get; set; }
        public string FullName { get; set; }
        public EnumCollection.Roles Role { get; set; }
        public Preference Preference { get; set; }
    }
}
