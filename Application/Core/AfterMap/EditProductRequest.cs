using Application.Data;
using Application.Features.Products.Edit;
using AutoMapper;
using Domain.Entities;

namespace Application.Core.AfterMap;

public class EditProductRequest : IMappingAction<Product, Product>
{
    private readonly IApplicationDbContext _context;

    public EditProductRequest(IApplicationDbContext context)
    {
        _context = context;
    }
    public void Process(Product source, Product destination, ResolutionContext context)
    {
        var category =  _context.Categories.Find(source.CategoryId);
        destination.Category = category;
    }
}