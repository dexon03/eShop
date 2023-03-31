using Application.Data;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Product.Id,cancellationToken);
        if (product is not null)
        {
            throw new InvalidOperationException("Product already exists");
        }

        await _context.Products.AddAsync(request.Product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}