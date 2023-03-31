using Domain.Entities;
using FluentValidation;

namespace Application.Features.Products.Create;

public class CreateProductValidator : AbstractValidator<Product>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        RuleFor(x => x.AvailableCount).NotEmpty().GreaterThan(-1);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(10);
        RuleFor(x => x.ShortDescription).NotEmpty().MinimumLength(5);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.VendorId).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
    }
}