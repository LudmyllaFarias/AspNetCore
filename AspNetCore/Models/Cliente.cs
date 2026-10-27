namespace AspNetCore.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;    
    public string PhoneNumber { get; set; } = string.Empty;

    // propriedade de navegação
    public List<Pedido> Pedidos { get; set; } = [];
}
