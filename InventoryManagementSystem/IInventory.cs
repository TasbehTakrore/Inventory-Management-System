namespace InventoryManagementSystem
{
    internal interface IInventory
    {
        void AddProduct(Product product);
        void DeleteProduct(string productName);
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string productName);
        bool IsProductAvailable(string name);
        void UpdateProduct(string productName, Product product);
    }
}