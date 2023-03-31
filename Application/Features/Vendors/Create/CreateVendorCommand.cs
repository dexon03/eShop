using Domain.Entities;
using MediatR;

namespace Application.Features.Vendors.Create;

public record CreateVendorCommand(Vendor Vendor) : IRequest;