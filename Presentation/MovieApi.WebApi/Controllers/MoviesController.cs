using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly GetMovieQueryHandler _getMoviesQueryHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMoviesQueryHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, CreateMovieCommandHandler createMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMoviesQueryHandler = getMoviesQueryHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
        }

        [HttpGet("[action]")]
        public async Task <IActionResult> GetAll()
        {
            var result = await _getMoviesQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task <IActionResult> GetById(int id)
        {
           var result= await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create (CreateMovieCommand command)
        {
            await _createMovieCommandHandler.handle(command);
            return Ok("Film Başarıyla Eklendi ! ");
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Film Başarıyla Silindi ! ");

        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.handle(command);
            return Ok("Film Başarıyla Güncellendi ! ");
        }

    }
}
