using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Get;

public class GetCategoryRequestHandler : IRequestHandler<GetCategoryQuery, Category>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
        if (category is null)
        {
            throw new KeyNotFoundException("Category not found");
        }
        return category;
    }
}