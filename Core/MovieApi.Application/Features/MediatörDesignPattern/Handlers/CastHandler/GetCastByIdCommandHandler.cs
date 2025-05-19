using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatörDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatörDesignPattern.Handlers.CastHandler;

public class GetCastByIdCommandHandler : IRequestHandler<CastGetByIdQuery, CastGetByIdQueryResult>
{
    private readonly MovieContext _context;

    public GetCastByIdCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<CastGetByIdQueryResult> Handle(CastGetByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _context.Casts.FindAsync(request.CastId);
        return new CastGetByIdQueryResult
        {
            CastId = value.CastId,
            Title = value.Title,
            Name=value.Name,
            Surname = value.Surname,
            ImageUrl = value.ImageUrl,
            Overview = value.Overview,
            Biography = value.Biography
        };
    }
}
