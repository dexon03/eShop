﻿using Application.Data;
using MediatR;
using Domain.Entities;

namespace Application.Features.Categories.Create;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.category);
        if (category is not null)
        {
            throw new Exception("Category already exists");
        }

        _context.Categories.Add(request.category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}