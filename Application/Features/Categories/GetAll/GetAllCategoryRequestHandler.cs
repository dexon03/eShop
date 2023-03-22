using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.GetAll;

public class GetAllCategoryRequestHandler : IRequestHandler<GetAllCategoryRequest, List<Category>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        
        return await _context.Categories.ToListAsync(cancellationToken: cancellationToken);
    }
}