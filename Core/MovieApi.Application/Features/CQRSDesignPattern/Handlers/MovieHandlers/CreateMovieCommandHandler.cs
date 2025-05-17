using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class CreateMovieCommandHandler
{
    private readonly MovieContext _context;

    public CreateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task handle(CreateMovieCommand command)
    {
        _context.Movies.Add(new Movie
        {
            CoverImageUrl=command.CoverImageUrl,
            Title= command.Title,
            Rating = command.Rating,
            Description = command.Description,
            Duration = command.Duration,
            ReleaseDate = command.ReleaseDate,
            CreatedYear = command.CreatedYear,
            Status = command.Status
        });

        await _context.SaveChangesAsync();
    }
}
