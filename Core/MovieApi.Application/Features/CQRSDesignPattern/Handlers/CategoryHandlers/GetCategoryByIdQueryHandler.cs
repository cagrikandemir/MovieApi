using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var values = await _context.Categories.FindAsync(query.CategoryId);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = values.CategoryId,
            CategoryName = values.CategoryName
        };
    }
}
