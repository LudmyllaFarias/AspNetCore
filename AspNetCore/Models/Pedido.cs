namespace AspNetCore.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }

    // propriedade de navegação
    public Cliente? Cliente { get; set; }
}
