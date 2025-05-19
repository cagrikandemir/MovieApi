using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatörDesignPattern.Handlers.CastHandler;

public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
{
    private readonly MovieContext _context;

    public UpdateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Casts.FindAsync(request.CastId);
        value.Title=request.Title;
        value.Name = request.Name;
        value.Surname = request.Surname;
        value.ImageUrl = request.ImageUrl;
        value.Overview = request.Overview;
        value.Biography = request.Biography;
        await _context.SaveChangesAsync();

    }
}
