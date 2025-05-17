using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task handle(UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.Rating = command.Rating;
        value.Status = command.Status;
        value.Duration = command.Duration;
        value.Description = command.Description;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Title = command.Title;
        value.ReleaseDate = command.ReleaseDate;
        value.CreatedYear = command.CreatedYear;
        await _context.SaveChangesAsync();
    }
}
