using System;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class ScheduleManager : IScheduleService
    {
        private IScheduleDal scheduleDal;
        public ScheduleManager(IScheduleDal scheduleDal)
        {
            this.scheduleDal = scheduleDal;
        }
        public async Task<IResult> DeleteAsync(Schedule entity)
        {
            try
            {
                await scheduleDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Schedule entity)
        {
            try
            {
                await scheduleDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Schedule entity)
        {
            try
            {
                await scheduleDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }
    }
}
