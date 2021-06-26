using System.Collections.Generic;
using ekip.Core.Entities.Concrete;

namespace ekip.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
