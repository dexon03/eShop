using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Get;

public record GetCategoryRequest(Guid Id) : IRequest<Category>;