
using AspNetCore.Entities.Customer.Request;

namespace AspNetCore.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public void Add(Entities.Customer.Request.CreateCustomerRequest request)
    {
        Console.WriteLine("Insere no banco.");
    }
}
