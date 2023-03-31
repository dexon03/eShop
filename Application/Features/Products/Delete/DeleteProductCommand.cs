using MediatR;

namespace Application.Features.Products.Delete;

public record DeleteProductCommand(Guid Id) : IRequest;