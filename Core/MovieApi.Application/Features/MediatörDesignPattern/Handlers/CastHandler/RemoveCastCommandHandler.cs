using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Commands.CastCommands;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatörDesignPattern.Handlers.CastHandler;

public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
{
    private readonly MovieContext _context;

    public RemoveCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
    {
        var value= await _context.Casts.FindAsync(request.CastId);
        if (value != null)
        {
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }
        else
            throw new Exception("Böyle Bir Cast Bulunamadı");

    }
}
