using AspNetCore.Data;
using AspNetCore.UseCase.Produto;
using AspNetCore.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CriarProdutoUseCase>();

var connectionString = builder.Configuration.GetConnectionString("StoreDb");

/*
 * AddDbContext = registra o contexto no sistem de injeção de dependência
 * UseMySql = configura o provedor do banco
 * ServerVersion = identifuca a versão do servidor do MySQL
 * 
 * O ASP.NET Core cria e disponibiliza o contexto quando um controller
 * precisa dele. Por padrão, o DbContext registrado dessa forma tem duraçãoSWS
 * Scoped, uma instância por escopo de requisição.
 */
builder.Services.AddDbContext<StoreDbContext>(opt =>
    opt.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        ));

// Registra o validator no program.cs
builder.Services.AddValidatorsFromAssemblyContaining<CriarProdutoValidador>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
 * Add-Migration CriarTabelaProdutos = O EF Core analisa minhas
 * entidades e o DbContext para gerar uma migration com as instruções necessárias
 * para criar a estrutura fo banco.
 * Se a migration foi criada com sucesso execute Update-Database
 */