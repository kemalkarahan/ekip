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
    public class BoardManager : IBoardService
    {
        private IBoardDal boardDal;
        public BoardManager(IBoardDal boardDal)
        {
            this.boardDal = boardDal;
        }
        public async Task<IResult> DeleteAsync(Board entity)
        {
            try
            {
                await boardDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(Board entity)
        {
            try
            {
                await boardDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(Board entity)
        {
            try
            {
                await boardDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<Board>> RetrieveByIdAsync(int id)
        {
            try
            {
                return new SuccessDataResult<Board>(await boardDal.RetrieveWithContexts(b => b.Id == id));
            }
            catch (Exception)
            {
                return new ErrorDataResult<Board>(InfoMessages.Error);
            }
        }

        public async Task<IDataResult<List<Board>>> RetrieveAllByInstitutionIdAsync(int institutionId, int followerId)
        {
            try
            {
                var list = await boardDal.RetrieveAll(b => b.InstitutionId == institutionId && b.Followers.Any(f => f.Id == followerId));

                return new SuccessDataResult<List<Board>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<Board>>(InfoMessages.Error);
            }
        }
    }
}
