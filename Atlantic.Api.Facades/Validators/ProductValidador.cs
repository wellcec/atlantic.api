using Atlantic.Api.Models.DTOs;
using FluentValidation;

namespace Atlantic.Api.Facades.Validators
{
    public class ProductValidador : AbstractValidator<ProductDTO>
    {

        public ProductValidador()
        {
            RuleFor(a => a.title)
                .NotEmpty()
                .WithMessage("Título não pode ser vazio");

            RuleFor(a => a.value)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Produto deve conter algum valor");

            RuleFor(a => a.valueUnique)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Produto deve conter algum valor único");

            RuleFor(a => a.images)
                .NotEmpty()
                .WithMessage("Produto deve conter alguma imagem");

            RuleFor(a => a.tags)
                .NotEmpty()
                .WithMessage("Produto deve conter alguma tag para pesquisa");

            RuleFor(a => a.variations)
                .NotEmpty()
                .WithMessage("Produto deve conter alguma variação de escolha");

            RuleFor(a => a.categories)
                .NotEmpty()
                .WithMessage("Produto deve conter alguma categoria");
        }
    }
}
