using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly MovieContext _contex;

    public CreateCategoryCommandHandler(MovieContext contex)
    {
        _contex = contex;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        _contex.Categories.Add(new Category
        {
            CategoryName = command.CategoryName
        });
       await _contex.SaveChangesAsync();
    }
}
