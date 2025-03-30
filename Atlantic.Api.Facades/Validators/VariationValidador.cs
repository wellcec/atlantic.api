using Atlantic.Api.Models.Context.Products;
using FluentValidation;

namespace Atlantic.Api.Facades.Validators
{
    public class VariationValidator : AbstractValidator<Variation>
    {

        public VariationValidator() 
        {
            RuleFor(a => a.name)
                .NotEmpty()
                .WithMessage("Name cannot be empty");
        }
    }
}
