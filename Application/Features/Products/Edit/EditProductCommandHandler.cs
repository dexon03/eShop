﻿using Application.Data;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Edit;

public class EditProductCommandHandler : IRequestHandler<EditProductCommand,Unit>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EditProductCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Product.Id);

        if (product is null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _mapper.Map(request.Product, product);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}