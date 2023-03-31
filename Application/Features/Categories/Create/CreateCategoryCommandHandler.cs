using Application.Data;
using MediatR;

namespace Application.Features.Categories.Create;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.category.Id);
        if (category is not null)
        {
            throw new InvalidOperationException("Category already exists");
        }

        _context.Categories.Add(request.category);
        await _context.SaveChangesAsync(cancellationToken);
        
    }
}