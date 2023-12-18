
using InventoryManagementSystem.DB;

namespace InventoryManagementSystem
{
    internal class Inventory : IInventory
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();
        IDbManager _dbManager;
        public Inventory(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }
        public void AddProduct(Product product)
        {
            _dbManager.AddProduct(product);
        }
        public bool IsProductAvailable(string name)
        {
            return _dbManager.IsProductAvailable(name);
        }
        public void UpdateProduct(string productName, Product product)
        {
            _dbManager.UpdateProduct(productName, product);
        }
        public void DeleteProduct(string productName)
        {
            _dbManager.DeleteProduct(productName);
        }

        public Product GetProduct(string productName)
        {
            return _dbManager.GetProduct(productName);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _dbManager.GetAllProducts();
        }
    }
}
