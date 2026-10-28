using AspNetCore.Data;
using AspNetCore.DTOs.Pedido;
using AspNetCore.DTOs.Cliente;
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

    public List<PedidoResponse> Executar()
    {
        /*
         * O include determina que os dados de uma entidade
         * relacionada também sejam carregados naquela consulta
         */

        var pedido = _dbContext.Pedidos
            .Select(p => new PedidoResponse
            {
                Id = p.Id,
                DataPedido = p.DataPedido,
                ValorTotal = p.ValorTotal,

                Cliente = new ClientePedidoResponse
                {
                    Nome = p.Cliente.Nome
                }
            }).ToList();
      
        return pedido;
    }
}
