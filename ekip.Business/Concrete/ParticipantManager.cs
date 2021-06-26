using System;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class ParticipantManager : IParticipantService
    {
        private IParticipantDal participantDal;
        public ParticipantManager(IParticipantDal participantDal)
        {
            this.participantDal = participantDal;
        }
        public async Task<IResult> DeleteAsync(Participant entity)
        {
            try
            {
                await participantDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Participant entity)
        {
            try
            {
                await participantDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Participant entity)
        {
            try
            {
                await participantDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckParticipantExistInListAsync(int participantId, int eventId)
        {
            return await participantDal.Check(p => p.EventId == eventId && p.AttendeeId == participantId);
        }
    }
}
