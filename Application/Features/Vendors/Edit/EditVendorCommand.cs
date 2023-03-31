using Domain.Entities;
using MediatR;

namespace Application.Features.Vendors.Edit;

public record EditVendorCommand(Vendor Vendor) : IRequest;