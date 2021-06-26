using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Dtos
{
    public class UserSignInDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
