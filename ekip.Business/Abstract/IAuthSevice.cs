using System.Threading.Tasks;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;
using ekip.Core.Utilities.Security.Jwt;
using ekip.Entities.Dtos;

namespace ekip.Business.Abstract
{
    public interface IAuthSevice
    {
        Task<IDataResult<User>> Register(UserRegistrationDto userRegistrationDto, string password);
        IDataResult<User> SignIn(UserSignInDto userSignInDto);
        Task<IResult> UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
