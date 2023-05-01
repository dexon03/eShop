using FluentValidation;

namespace Application.Features.Categories.Create;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.category.Name).NotEmpty().MinimumLength(2);
    }
}