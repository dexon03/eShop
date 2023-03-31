using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Create;

public record CreateProductCommand(Product Product) : IRequest;