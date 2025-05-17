using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly MovieContext _contex;

    public UpdateCategoryCommandHandler(MovieContext contex)
    {
        _contex = contex;
    }
    public async Task Handle(UpdateCategoryCommand command)
    {
        var value = await _contex.Categories.FindAsync(command.CategoryId);
        value.CategoryName=command.CategoryName;
        await _contex.SaveChangesAsync();
    }
}
