using Application.Data;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Edit;

public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EditCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Category.Id);
        if (category is null)
        {
            throw new Exception("Category not found");
        }
        _mapper.Map(request.Category, category);
        
    }
}