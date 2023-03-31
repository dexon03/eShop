using Domain.Entities;
using MediatR;

namespace Application.Features.Vendors.GetAll;

public record GetAllVendorsQuery() : IRequest<List<Vendor>>;
