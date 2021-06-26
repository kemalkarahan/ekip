using System;
using System.Linq;
using System.Threading.Tasks;
using ekip.Business.Abstract;
using ekip.Core.Constants;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;
using ekip.Core.Utilities.Security.Hashing;
using ekip.Core.Utilities.Security.Jwt;
using ekip.Entities.Concrete;
using ekip.Entities.Dtos;

namespace ekip.Business.Concrete
{
    public class AuthManager : IAuthSevice
    {
        private readonly IUserService _userService;
        private readonly IInstitutionService _institutionService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IInstitutionService institutionService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _institutionService = institutionService;
        }

        public async Task<IDataResult<User>> Register(UserRegistrationDto userRegistrationDto, string password)
        {
            string domain =
                userRegistrationDto.Email.Substring(userRegistrationDto.Email.IndexOf("@"));

            if (!(await _institutionService.CheckAsync(i=>i.Code==userRegistrationDto.InstitutionCode && i.Domain == domain)))
            {
                return new ErrorDataResult<User>(InfoMessages.MissingOrWrongInformation);
            }

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var institution = await _institutionService.RetrieveByCodeAsync(userRegistrationDto.InstitutionCode);

            var user = new Staff
            {
                Name = userRegistrationDto.Name,
                Surname = userRegistrationDto.Name,
                Email = userRegistrationDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false,
                DisplayName = string.Concat("@", userRegistrationDto.Email.Remove(userRegistrationDto.Email.IndexOf("@"))),
                InstitutionId = institution.Data.Id,
                AboutMe = "",
                LinkedIn = "",
                Title = "",
                PersonalWebPage = "",
                ProfilePicture = ""
            };
            //E-posta doğrulama postası yollanacak.
            await _userService.InsertAsync(user);

            return new SuccessDataResult<User>(user, InfoMessages.ConfirmEmail);
        }

        public IDataResult<User> SignIn(UserSignInDto userSignInDto)
        {
            var userToCheck = _userService.RetrieveByEmailAsync(userSignInDto.Email);
            
            if (!userToCheck.Result.Success)
            {
                return new ErrorDataResult<User>(InfoMessages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userSignInDto.Password, userToCheck.Result.Data.PasswordHash, userToCheck.Result.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(InfoMessages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Result.Data, InfoMessages.SuccessfulLogin);
        }

        public async Task<IResult> UserExists(string email)
        {
            bool userToCheck = await _userService.CheckUserExistsAsync(email);
            if (userToCheck)
            {
                return new ErrorResult(InfoMessages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.RetrieveClaimsAsync(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Result.Data.ToList());

            return new SuccessDataResult<AccessToken>(accessToken, InfoMessages.AccessTokenCreated);
        }
    }
}
