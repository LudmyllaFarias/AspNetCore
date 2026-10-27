using AspNetCore.Data;
using AspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.UseCase.Pedido;

public class ListaPedidoUseCase
{
    private readonly StoreDbContext _dbContext;

    public ListaPedidoUseCase(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<AspNetCore.Models.Pedido> Executar()
    {
        var pedido = _dbContext.Pedidos
            .Include(x => x.Cliente)
            .ToList();
        return pedido;
    }
}
