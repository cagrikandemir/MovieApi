using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _contex;

    public RemoveCategoryCommandHandler(MovieContext contex)
    {
        _contex = contex;
    }

    public async Task Handle(RemoveCategoryCommand command)
    {
        var value = await _contex.Categories.FindAsync(command.CategoryId);
        if (value != null)
        {
            _contex.Remove(value);
            await _contex.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Category not found");
        }
    }
}
