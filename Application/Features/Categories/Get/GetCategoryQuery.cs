using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Get;

public record GetCategoryQuery(Guid Id) : IRequest<Category>;