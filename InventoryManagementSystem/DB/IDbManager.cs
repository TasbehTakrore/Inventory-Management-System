using System.Data.SqlClient;

namespace InventoryManagementSystem.DB
{
    internal interface IDbManager
    {
        void AddProduct(Product product);
        void DeleteProduct(string productName);
        IEnumerable<Product> GetAllProducts();
        SqlConnection GetConnection();
        Product? GetProduct(string keyName);
        bool IsProductAvailable(string productName);
        void UpdateProduct(string keyNam, Product product);
    }
}