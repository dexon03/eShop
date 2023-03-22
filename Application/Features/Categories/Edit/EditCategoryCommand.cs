using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Edit;

public record EditCategoryCommand(Category Category) : IRequest;