
namespace AspNetCore.Repositories;

public interface ICustomerRepository
{
    void Add(Entities.Customer.Request.CreateCustomerRequest request);
}
