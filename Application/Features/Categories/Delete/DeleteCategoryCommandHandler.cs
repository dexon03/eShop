﻿using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Delete;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.id);
        if(category is null)
        {
            throw new KeyNotFoundException("Category not found");
        }
        
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}