using System.Threading.Tasks;
using ekip.Business.Abstract;
using ekip.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ekip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthSevice _authSevice;

        public AuthController(IAuthSevice authSevice)
        {
            _authSevice = authSevice;
        }

        [HttpPost("signin")]
        public IActionResult SignIn(UserSignInDto userSignInDto)
        {
            var userToSignIn = _authSevice.SignIn(userSignInDto);
            if (!userToSignIn.Success)
            {
                return BadRequest(userToSignIn.Message);
            }

            var result = _authSevice.CreateAccessToken(userToSignIn.Data);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            var userExists = await _authSevice.UserExists(userRegistrationDto.Email);

            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authSevice.Register(userRegistrationDto, userRegistrationDto.Password);

            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }

            var result = _authSevice.CreateAccessToken(registerResult.Data);
            
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
