using Application.Data;
using AutoMapper;
using MediatR;

namespace Application.Features.Vendors.Edit;

public class EditVendorCommandHandler : IRequestHandler<EditVendorCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EditVendorCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(EditVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FindAsync(request.Vendor.Id, cancellationToken);
        if (vendor is null)
        {
            throw new KeyNotFoundException();
        }

        _mapper.Map(request.Vendor, vendor);
        await _context.SaveChangesAsync(cancellationToken);
    }
}