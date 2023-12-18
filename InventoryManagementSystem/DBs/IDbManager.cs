using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DB
{
    internal interface IDbManager
    {
        void AddProduct(Product product);
        void DeleteProduct(string productName);
        IEnumerable<Product> GetAllProducts();
        Product? GetProduct(string productName);
        bool IsProductAvailable(string productName);
        void UpdateProduct(string productName, Product product);
    }
}