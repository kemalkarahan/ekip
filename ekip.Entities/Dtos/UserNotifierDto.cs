using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Dtos
{
    public class UserNotifierDto : IDto
    {
        public string ContactInfo { get; set; }
        public string FullName { get; set; }
    }
}
