using System.Data;
using Dapper;

namespace ORM_Dapper_Exercise_BestBuy;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connectionP;

    public ProductRepository(IDbConnection connectionP)
    {
        _connectionP = connectionP;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connectionP.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _connectionP.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                             "VALUES (@name, @price, @categoryID)", new {name, price, categoryID});
    }

    public void UpdateProduct(string name, double price, int onSale)
    {
        _connectionP.Execute("UPDATE products SET Price = (@price), OnSale = (@onSale)" +
                             "WHERE Name = (@name)", new {name, price, onSale});
    }
}