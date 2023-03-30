using Application.Data;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.GetAll;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        
        return await _context.Categories.ToListAsync(cancellationToken: cancellationToken);
    }
}