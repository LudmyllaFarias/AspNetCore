using AspNetCore.DTOs.Cliente;
using FluentValidation;

namespace AspNetCore.Validators;

public class CriaClienteValidador : AbstractValidator<CriarClienteRequest>
{
    public CriaClienteValidador()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome é obrigatório!")
            .MaximumLength(255)
            .WithMessage("O nome deve ter no máximo 255 caracteres!");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("O número de telefone é obrigatório!")
            .MaximumLength(20)
            .WithMessage("O número de telefone deve ter no máximo 20 caracteres!");
    }
}
