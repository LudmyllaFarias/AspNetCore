using AspNetCore.Entities.Customer.Request;
using AspNetCore.Repositories;

namespace AspNetCore.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Register(Entities.Customer.Request.CreateCustomerRequest request)
    {
        Console.WriteLine("Valida dados.");
        _customerRepository.Add(request);
    }
}
