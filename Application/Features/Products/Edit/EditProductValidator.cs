using FluentValidation;

namespace Application.Features.Products.Edit;

public class EditProductValidator : AbstractValidator<EditProductCommand>
{
    public EditProductValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Product.Price).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Product.AvailableCount).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Product.Description).NotEmpty().MinimumLength(10);
        RuleFor(x => x.Product.ShortDescription).NotEmpty().MinimumLength(5);
        RuleFor(x => x.Product.CategoryId).NotEmpty();
        RuleFor(x => x.Product.ImageUrl).NotEmpty();
    }
}