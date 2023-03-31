using Application.Data;
using MediatR;

namespace Application.Features.Vendors.Create;

public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateVendorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FindAsync(request.Vendor.Id, cancellationToken);
        if (vendor is not null)
        {
            throw new InvalidOperationException("Vendor already exists");
        }
        
        _context.Vendors.Add(request.Vendor);
        await _context.SaveChangesAsync(cancellationToken);
    }
}