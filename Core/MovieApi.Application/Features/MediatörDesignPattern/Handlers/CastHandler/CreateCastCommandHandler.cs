﻿using MediatR;
using MovieApi.Application.Features.MediatörDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistance.Context;

namespace MovieApi.Application.Features.MediatörDesignPattern.Handlers.CastHandler;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
         _context.Casts.Add(new Cast
        {
            Title = request.Title,
            Name = request.Name,
            Surname = request.Surname,
            ImageUrl = request.ImageUrl,
            Overview = request.Overview,
            Biography = request.Biography
        });
        await _context.SaveChangesAsync();
    }
}
