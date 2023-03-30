using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.GetAll;

public record GetAllCategoryQuery() : IRequest<List<Category>>;