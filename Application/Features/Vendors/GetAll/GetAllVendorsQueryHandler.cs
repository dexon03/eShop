using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Vendors.GetAll;

public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, List<Vendor>>
{
    private readonly IApplicationDbContext _context;

    public GetAllVendorsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Vendor>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Vendors.ToListAsync(cancellationToken: cancellationToken);
    }
}