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
    public class BoardContextManager : IBoardContextService
    {
        private IBoardContextDal boardContextDal;
        public BoardContextManager(IBoardContextDal boardContextDal)
        {
            this.boardContextDal = boardContextDal;
        }
        public async Task<IResult> DeleteAsync(BoardContext entity)
        {
            try
            {
                await boardContextDal.Delete(entity);
                return new SuccessResult(InfoMessages.Deleted);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> InsertAsync(BoardContext entity)
        {
            try
            {
                await boardContextDal.Insert(entity);
                return new SuccessResult(InfoMessages.Added);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }

        public async Task<IResult> UpdateAsync(BoardContext entity)
        {
            try
            {
                await boardContextDal.Update(entity);
                return new SuccessResult(InfoMessages.Updated);
            }
            catch (Exception)
            {
                return new ErrorResult(InfoMessages.Error);
            }
        }
        
        public async Task<IDataResult<List<BoardContext>>> RetrieveAllByWriterIdAsync(int writerId, int boardId)
        {
            try
            {
                var list = await boardContextDal.RetrieveAll(b => b.BoardId == boardId && b.WriterId == writerId);
                return new SuccessDataResult<List<BoardContext>>(list.ToList());
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<BoardContext>>(InfoMessages.Error);
            }
        }
    }
}
