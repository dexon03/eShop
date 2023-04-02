using Application.Data;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Product.Id);
        if (product is not null)
        {
            throw new InvalidOperationException("Product already exists");
        }

        await _context.Products.AddAsync(request.Product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}