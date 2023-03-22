using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Create;

public record CreateCategoryCommand(Category category) : IRequest;
