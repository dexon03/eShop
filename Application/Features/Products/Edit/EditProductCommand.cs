using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Edit;

public record EditProductCommand(Product Product) : IRequest;