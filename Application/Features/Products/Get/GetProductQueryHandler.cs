using Application.Data;
using Domain.Entities;
using MediatR;

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
        var product = await _context.Products.FindAsync(request.Id);
        if (product is null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return product;
    }
}