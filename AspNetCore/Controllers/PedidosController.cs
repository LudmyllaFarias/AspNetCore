using AspNetCore.DTOs.Cliente;
using AspNetCore.DTOs.Pedido;
using AspNetCore.UseCase.Pedido;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly CriaPedidoUseCase _useCase;
    private readonly ListaPedidoUseCase _listaUseCase;

    public PedidosController(CriaPedidoUseCase useCase, ListaPedidoUseCase listaUseCase)
    {
        _useCase = useCase;
        _listaUseCase = listaUseCase;
    }

    [HttpPost]
    public IActionResult Cadastra(CriaPedidoRequest request)
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

    [HttpGet]
    public IActionResult Lista()
    {
        var response = _listaUseCase.Executar();
        return Ok(response);
    }
}
