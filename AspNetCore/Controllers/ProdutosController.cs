using AspNetCore.DTOs.Produto;
using AspNetCore.Models;
using AspNetCore.UseCase.Produto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly CriarProdutoUseCase _useCase;

    public ProdutosController(CriarProdutoUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Busca()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Cadastra(CriarProdutoRequest request)
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
