namespace AspNetCore.DTOs.Pedido;

public class CriaPedidoRequest
{
    public int ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
}
