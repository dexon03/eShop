using Domain.Entities;
using MediatR;

namespace Application.Features.Vendors.Get;

public record GetVendorQuery(Guid Id) : IRequest<Vendor>;