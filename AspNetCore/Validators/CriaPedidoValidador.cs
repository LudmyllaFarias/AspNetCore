using AspNetCore.DTOs.Pedido;
using FluentValidation;

namespace AspNetCore.Validators;

public class CriaPedidoValidador :AbstractValidator<CriaPedidoRequest>
{
    public CriaPedidoValidador()
    {
        RuleFor(x => x.ClienteId)
            .NotEmpty()
            .WithMessage("O cliente é obrigatório!");

        RuleFor(x => x.DataPedido)
            .NotEmpty()
            .WithMessage("A data do pedido é obrigatório!")
            .Must(data => data.Date <= DateTime.Today)
            .WithMessage("A data do pedido não pode ser futura.");

        RuleFor(x => x.ValorTotal)
           .GreaterThan(0)
           .WithMessage("O valor total deve ser maior que zero.");
    }
}
