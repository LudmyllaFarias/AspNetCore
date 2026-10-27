using AspNetCore.Data;
using AspNetCore.DTOs.Produto;
using AspNetCore.Validators;
using FluentValidation;

namespace AspNetCore.UseCase.Produto;

public class CriarProdutoUseCase
{
    private readonly StoreDbContext _dbContext;
    private readonly IValidator<CriarProdutoRequest> _validador;

    public CriarProdutoUseCase(StoreDbContext dbContext, IValidator<CriarProdutoRequest> validador)
    {
        _dbContext = dbContext;
        _validador = validador;
    }

    public AspNetCore.Models.Produto Executar(CriarProdutoRequest request)
    {
        var result = _validador.Validate(request);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var produto = new AspNetCore.Models.Produto()
        {
            Nome = request.Nome,
            Preco = request.Preco,
        };

        _dbContext.Produtos.Add(produto);

        _dbContext.SaveChanges();

        return produto;
    }
}
