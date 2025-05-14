using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductoService.Application.Consumers;
using ProductoService.Application.Mappings;
using ProductoService.Application.Services;
using ProductoService.Domain.Interfaces;
using ProductoService.Infrastructure.Data.MongoDb;
using ProductoService.Infrastructure.Data.PostgresDb;
using ProductoService.Infrastructure.Repositories;
using ProductoService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<ProductoWriteDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddSingleton<ProductoReadDbContext>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// MassTransit-RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductoCreatedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        cfg.ConfigureEndpoints(context);
    });
});

// Dependency Injection
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService.Application.Services.ProductoService>();

// Registro de DbContext para Subasta
builder.Services.AddDbContext<SubastaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Registro de repositorio y servicio de Subasta
builder.Services.AddScoped<ISubastaRepository, SubastaRepository>();
builder.Services.AddScoped<ISubastaService, SubastaService>();

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