using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Dtos
{
    public class UserRegistrationDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int InstitutionCode { get; set; }
    }
}
