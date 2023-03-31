using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Get;

public record GetProductQuery(Guid Id) : IRequest<Product>;