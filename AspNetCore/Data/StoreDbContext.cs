using AspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data;

/*
 * DbContext: classe base do entityFrameworkCore
 */
public class StoreDbContext : DbContext
{
    // Recebe as configurações do contexto, incluíndo quando banco será utilizado
    public StoreDbContext(DbContextOptions options) : base(options) // passa essas configurações para a classe base
    {
    } 

    /*
     * Representa a coleção de produtos que EF Core poderá consultar e persistir.
     * A partir dela, o EF Core pode mapear a entidade Produto para uma tabela chamada Produtos
     */
    public DbSet<Produto> Produtos { get; set; }
}
