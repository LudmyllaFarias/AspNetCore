using AspNetCore.Entities.Customer.Request;

namespace AspNetCore.Services;

public interface ICustomerService
{
    void Register(Entities.Customer.Request.CreateCustomerRequest createCustomerRequest);
}
