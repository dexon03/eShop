using Application.Data;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vendors.Get;

public class GetVendorQueryHandler : IRequestHandler<GetVendorQuery, Vendor>
{
    private readonly IApplicationDbContext _context;

    public GetVendorQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Vendor> Handle(GetVendorQuery request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FindAsync(request.Id, cancellationToken);
        
        if(vendor is null)
            throw new KeyNotFoundException(nameof(Vendor));
        
        return vendor;
    }
}