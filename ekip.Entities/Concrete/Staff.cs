using System.Collections.Generic;
using ekip.Core.Entities.Concrete;

namespace ekip.Entities.Concrete
{
    public class Staff : User
    {
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
        public string DisplayName { get; set; }
        public int Phone { get; set; }
        public string Title { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicture { get; set; }
        public string PersonalWebPage { get; set; }
        public string LinkedIn { get; set; }
        public virtual List<Member> Members { get; set; }
    }
}
