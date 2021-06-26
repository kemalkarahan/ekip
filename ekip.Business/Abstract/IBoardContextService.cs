using System.Collections.Generic;
using ekip.Entities.Concrete;
using System.Threading.Tasks;
using ekip.Core.Utilities.Results;

namespace ekip.Business.Abstract
{
    public interface IBoardContextService
    {
        Task<IResult> InsertAsync(BoardContext entity);
        Task<IResult> DeleteAsync(BoardContext entity);
        Task<IResult> UpdateAsync(BoardContext entity);
        Task<IDataResult<List<BoardContext>>> RetrieveAllByWriterIdAsync(int writerId, int boardId);
    }
}
