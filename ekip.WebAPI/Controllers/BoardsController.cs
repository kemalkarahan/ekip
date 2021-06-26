using System.Threading.Tasks;
using ekip.Business.Abstract;
using ekip.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ekip.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardContextService _boardContextSevice;
        private readonly IBoardService _boardService;

        public BoardsController(IBoardContextService boardContextSevice, IBoardService boardService)
        {
            this._boardContextSevice = boardContextSevice;
            this._boardService = boardService;
        }
        [HttpGet("get")]
        [Authorize()]
        public async Task<IActionResult> GetBoard(int writerId, int boardId)
        {
            var result = await _boardContextSevice.RetrieveAllByWriterIdAsync(writerId, boardId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        [Authorize()]
        public async Task<IActionResult> GetBoards(int institutionId)
        {
            var result = await _boardService.RetrieveByIdAsync(institutionId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("insert")]
        [Authorize()]
        public async Task<IActionResult> AddBoard(BoardContext boardContext)
        {
            var result = await _boardContextSevice.InsertAsync(boardContext);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize()]
        public async Task<IActionResult> UpdateBoard(BoardContext boardContext)
        {
            var result = await _boardContextSevice.UpdateAsync(boardContext);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Delete.Board")]
        public async Task<IActionResult> DeleteBoard(BoardContext boardContext)
        {
            var result = await _boardContextSevice.DeleteAsync(boardContext);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
