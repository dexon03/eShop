using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Get;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IApplicationDbContext _context;

    public GetProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Vendor)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return product;
    }
}