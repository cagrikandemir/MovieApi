using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatörDesignPattern.Queries.CastQueries;

public class CastGetByIdQuery : IRequest<CastGetByIdQueryResult>
{
    public int CastId { get; set; }

    public CastGetByIdQuery(int castId)
    {
        CastId = castId;
    }
}
