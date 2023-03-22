using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Get;

public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, Category>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Category> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        if (category is null)
        {
            throw new Exception("Category not found");
        }
        return category;
    }
}