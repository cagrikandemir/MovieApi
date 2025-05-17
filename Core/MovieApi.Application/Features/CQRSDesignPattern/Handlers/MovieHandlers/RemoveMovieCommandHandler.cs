using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class RemoveMovieCommandHandler
{
    private readonly MovieContext _contex;

    public RemoveMovieCommandHandler(MovieContext contex)
    {
        _contex = contex;
    }
    public async Task Handle(RemoveMovieCommand command)
    {
        var value= await _contex.Movies.FindAsync(command.MovieId);
        if(value != null)
        {
            _contex.Remove(value);
            await _contex.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Movie not found");
        }
    }
}
