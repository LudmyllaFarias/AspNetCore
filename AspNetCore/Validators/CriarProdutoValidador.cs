using AspNetCore.DTOs.Produto;
using FluentValidation;

namespace AspNetCore.Validators;

public class CriarProdutoValidador : AbstractValidator<CriarProdutoRequest>
{
    public CriarProdutoValidador()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome é obrigatório!")
            .MaximumLength(100)
            .WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Preco)
            .GreaterThan(0)
            .WithMessage("O preço deve ser maior que zero");
    }
}
