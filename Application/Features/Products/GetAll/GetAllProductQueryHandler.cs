using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.GetAll;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
{
    private readonly IApplicationDbContext _context;

    public GetAllProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(nameof(Category))
            .Include(nameof(Vendor))
            .ToListAsync(cancellationToken);
    }
}