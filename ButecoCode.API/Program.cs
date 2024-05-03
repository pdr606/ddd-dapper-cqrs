using ButecoCode.Application.Input.Commands.Produto;
using ButecoCode.Application.Input.Handlers.Produto;
using ButecoCode.Application.Repositories.Produto;
using ButecoCode.Infrastructure.Repository.Produto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<InserirProdutoHandler>();
builder.Services.AddTransient<InserirProdutoCommand>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
