using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatörDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatörDesignPattern.Results.CastResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatörDesignPattern.Handlers.CastHandler;

public class GetCastCommandHandler : IRequestHandler<CastGetQuery,List<CastGetQueryResult>>
{
    private readonly MovieContext _context;

    public GetCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<CastGetQueryResult>> Handle(CastGetQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Casts.ToListAsync();
        return values.Select(x => new CastGetQueryResult
        {
            Biography = x.Biography,
            CastId = x.CastId,
            ImageUrl = x.ImageUrl,
            Overview = x.Overview,
            Surname = x.Surname,
            Title = x.Title
        }).ToList();
    }
}
