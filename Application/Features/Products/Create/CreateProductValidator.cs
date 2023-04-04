using Domain.Entities;
using FluentValidation;

namespace Application.Features.Products.Create;

public sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Product.Price).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Product.AvailableCount).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Product.Description).NotEmpty().MinimumLength(10);
        RuleFor(x => x.Product.ShortDescription).NotEmpty().MinimumLength(5);
        RuleFor(x => x.Product.CategoryId).NotEmpty();
    }
}