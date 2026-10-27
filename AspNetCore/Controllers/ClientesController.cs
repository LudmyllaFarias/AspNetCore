using AspNetCore.DTOs.Cliente;
using AspNetCore.UseCase.Cliente;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly CriaClienteUseCase _useCase;

    public ClientesController(CriaClienteUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public IActionResult Cadastra(CriarClienteRequest request)
    {
        try
        {
            var response = _useCase.Executar(request);

            return Created(string.Empty, response);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new
            {
                erros = ex.Errors.Select(erro => erro.ErrorMessage)
            });
        }
    }
}
