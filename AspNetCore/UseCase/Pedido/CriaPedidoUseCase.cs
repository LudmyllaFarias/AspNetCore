using AspNetCore.Data;
using AspNetCore.DTOs.Pedido;
using FluentValidation;

namespace AspNetCore.UseCase.Pedido;

public class CriaPedidoUseCase
{
    private readonly StoreDbContext _dbContext;
    private readonly FluentValidation.IValidator<CriaPedidoRequest> _validator;

    public CriaPedidoUseCase(StoreDbContext dbContext, IValidator<CriaPedidoRequest> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    public AspNetCore.Models.Pedido Executar(CriaPedidoRequest request)
    {
        var result = _validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var pedido = new AspNetCore.Models.Pedido()
        {
            ClienteId = request.ClienteId,
            DataPedido = request.DataPedido,
            ValorTotal = request.ValorTotal,
        };

        _dbContext.Pedidos.Add(pedido);

        _dbContext.SaveChanges();

        return pedido;
    }
}
