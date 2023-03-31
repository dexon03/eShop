using Domain.Entities;
using MediatR;

namespace Application.Features.Products.GetAll;

public record GetAllProductQuery() : IRequest<List<Product>>;