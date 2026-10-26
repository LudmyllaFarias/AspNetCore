using AspNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Config;

/*
 * DbContext - classe do entityFramework que nossa classe herda para 
 * obter funcionalidades de acesso ao banco.
 */
public class OrdersDbContext : DbContext
{
    // Representa um conjunto de customers que podemos consultar e manipular pelo entityFramework
    public DbSet<Customer> Customers {  get; set; }
}
