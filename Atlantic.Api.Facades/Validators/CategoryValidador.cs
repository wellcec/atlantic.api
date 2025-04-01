using Atlantic.Api.Models.Context.Products;
using FluentValidation;

namespace Atlantic.Api.Facades.Validators
{
    public class CategoryValidador : AbstractValidator<Category>
    {

        public CategoryValidador()
        {
            RuleFor(a => a.name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio");
        }
    }
}
