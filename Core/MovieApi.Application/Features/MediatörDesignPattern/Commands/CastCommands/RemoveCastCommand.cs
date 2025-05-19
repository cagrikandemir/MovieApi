using MediatR;

namespace MovieApi.Application.Features.MediatörDesignPattern.Commands.CastCommands;

public class RemoveCastCommand : IRequest
{
    public int CastId { get; set; }

    public RemoveCastCommand(int castId)
    {
        CastId = castId;
    }
}
