using AspNetCore.DTOs.Cliente;

namespace AspNetCore.DTOs.Pedido;

public class PedidoResponse
{
    public int Id { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public ClientePedidoResponse? Cliente { get; set; }
}
