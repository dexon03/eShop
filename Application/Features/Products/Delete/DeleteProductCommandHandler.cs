using Application.Data;
using MediatR;

namespace Application.Features.Products.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        
        if (product is null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}