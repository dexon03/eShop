using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.GetAll;

public record GetAllCategoryRequest() : IRequest<List<Category>>;