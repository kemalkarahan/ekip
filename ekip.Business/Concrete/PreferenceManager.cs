using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ekip.Business.Abstract;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;

namespace ekip.Business.Concrete
{
    public class PreferenceManager : IPreferenceService
    {
        private IPreferenceDal preferenceDal;

        public PreferenceManager(IPreferenceDal preferenceDal)
        {
            this.preferenceDal = preferenceDal;
        }

        public async Task<IResult> InsertAsync(Preference entity)
        {
            try
            {
                await preferenceDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Preference entity)
        {
            try
            {
                await preferenceDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> DeleteAsync(Preference entity)
        {
            try
            {
                await preferenceDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Preference>> RetrieveByIdAsync(int preferenceId)
        {
            try
            {
                return new SuccessDataResult<Preference>(await preferenceDal.Retrieve(p => p.Id == preferenceId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Preference>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Preference>>> RetrieveAllAsyns(int staffId)
        {
            try
            {
                var list = await preferenceDal.RetrieveAll(p => p.StaffId == staffId);
                return new SuccessDataResult<List<Preference>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Preference>>(InfoMessages.Error);
            }
        }
    }
}
