using AspNetCore.Data;
using AspNetCore.DTOs.Cliente;
using AspNetCore.Validators;
using FluentValidation;

namespace AspNetCore.UseCase.Cliente;

public class CriaClienteUseCase
{
    private readonly StoreDbContext _dbContext;
    private readonly IValidator<CriarClienteRequest> _validator;

    public CriaClienteUseCase(StoreDbContext dbContext, IValidator<CriarClienteRequest> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }

    public AspNetCore.Models.Cliente Executar(CriarClienteRequest request)
    {
        var result = _validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var cliente = new AspNetCore.Models.Cliente()
        {
            Nome = request.Nome,
            PhoneNumber = request.PhoneNumber,
        };

        _dbContext.Clientes.Add(cliente);

        _dbContext.SaveChanges();

        return cliente;
    }

}