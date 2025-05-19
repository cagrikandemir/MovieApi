using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatörDesignPattern.Queries.CastQueries;

public class CastGetQuery : IRequest<List<CastGetQueryResult>>
{
}
