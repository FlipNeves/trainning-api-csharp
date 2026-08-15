using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using TreinamentoDEV.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SessionDbContext>(options =>
    options.UseInMemoryDatabase("TreinamentoDEV"));

builder.Services.AddScoped<IGrupoComissaoRepository, GrupoComissaoRepository>();
builder.Services.AddScoped<IGrupoCompraRepository, GrupoCompraRepository>();
builder.Services.AddScoped<IGrupoDescontoRepository, GrupoDescontoRepository>();

builder.Services.AddScoped<IGrupoComissaoService, GrupoComissaoService>();
builder.Services.AddScoped<IGrupoCompraService, GrupoCompraService>();
builder.Services.AddScoped<IGrupoDescontoService, GrupoDescontoService>();
builder.Services.AddScoped<IArvoreMercadologicaAppService, ArvoreMercadologicaAppService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DbSeeder.Seed(scope.ServiceProvider.GetRequiredService<SessionDbContext>());
}

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
