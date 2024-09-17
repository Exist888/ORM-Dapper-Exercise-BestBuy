namespace ORM_Dapper_Exercise_BestBuy;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void CreateProduct(string name, double price, int categoryID);

    public void UpdateProduct(string name, double price, int onSale);
}