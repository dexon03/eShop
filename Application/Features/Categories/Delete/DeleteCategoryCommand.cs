using MediatR;

namespace Application.Features.Categories.Delete;

public record DeleteCategoryCommand(Guid id) : IRequest;
