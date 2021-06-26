using System;
using System.Linq.Expressions;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class InstitutionManager : IInstitutionService
    {
        private IInstitutionDal institutionDal;
        public InstitutionManager(IInstitutionDal institutionDal)
        {
            this.institutionDal = institutionDal;
        }
        public async Task<IResult> DeleteAsync(Institution entity)
        {
            try
            {
                await institutionDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Institution entity)
        {
            try
            {
                await institutionDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Institution entity)
        {
            try
            {
                await institutionDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Institution>> RetrieveByIdAsync(int institutionId)
        {
            try
            {
                return new SuccessDataResult<Institution>(await institutionDal.Retrieve(i => i.Id == institutionId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Institution>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Institution>> RetrieveByCodeAsync(int institutionCode)
        {
            try
            {
                return new SuccessDataResult<Institution>(await institutionDal.Retrieve(i => i.Code == institutionCode));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Institution>(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckAsync(Expression<Func<Institution, bool>> filter)
        {
            try
            {
                return await institutionDal.Check(filter);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
