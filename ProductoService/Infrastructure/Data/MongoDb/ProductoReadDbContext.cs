using MongoDB.Driver;
using ProductoService.Domain.Entities;

namespace ProductoService.Infrastructure.Data.MongoDb;

public class ProductoReadDbContext
{
    private readonly IMongoDatabase _database;
    private readonly string _collectionName = "Productos";

    public ProductoReadDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("ProductosReadDb");
    }

    public IMongoCollection<Producto> Productos => _database.GetCollection<Producto>(_collectionName);
} 