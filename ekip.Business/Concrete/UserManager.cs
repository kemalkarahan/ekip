using System;
using System.Collections.Generic;
using System.Linq;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Entities.Concrete;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public async Task<IResult> DeleteAsync(User entity)
        {
            try
            {
                await _userDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(User entity)
        {
            try
            {
                await _userDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(User entity)
        {
            try
            {
                await _userDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<User>> RetrieveByIdAsync(int userId)
        {
            try
            {
                return new SuccessDataResult<User>(await _userDal.Retrieve(u => u.Id == userId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<User>> RetrieveByEmailAsync(string email)
        {
            try
            {
                return new SuccessDataResult<User>(await _userDal.Retrieve(u => u.Email == email));
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<OperationClaim>>> RetrieveClaimsAsync(User user)
        {
            try
            {
                var list = await _userDal.RetrieveClaims(user);
                return new SuccessDataResult<List<OperationClaim>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<OperationClaim>>(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckUserExistsAsync(string email)
        {
            return await _userDal.Check(u => u.Email == email);
        }
    }
}
