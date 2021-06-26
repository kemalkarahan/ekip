using System;
using System.Collections.Generic;
using System.Linq;
using ekip.Business.Abstract;
using ekip.DataAccess.Abstract;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Constants;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Concrete
{
    public class EventManager : IEventService
    {
        private IEventDal eventDal;
        private IParticipantService participantService;
        public EventManager(IEventDal eventDal, IParticipantService participantService)
        {
            this.eventDal = eventDal;
            this.participantService = participantService;
        }
        public async Task<IResult> DeleteAsync(Event entity)
        {
            try
            {
                await eventDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Event entity)
        {
            try
            {
                await eventDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Event entity)
        {
            try
            {
                await eventDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Event>> RetrieveByIdAsync(int eventId)
        {
            try
            {
                return new SuccessDataResult<Event>(await eventDal.Retrieve(e => e.Id == eventId));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Event>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Participant>>> RetrieveParticipantsAsync(int eventId)
        {
            try
            {
                var list = await eventDal.RetrieveParticipants(eventId);
                return new SuccessDataResult<List<Participant>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Participant>>(InfoMessages.Error);
            }
        }

        public async Task<bool> CheckParticipantExistInListAsync(int participantId, int eventId)
        {
            return await participantService.CheckParticipantExistInListAsync(participantId, eventId);
        }
    }
}
