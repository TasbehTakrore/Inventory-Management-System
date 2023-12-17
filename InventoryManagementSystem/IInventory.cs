namespace InventoryManagementSystem
{
    internal interface IInventory
    {
        void AddProduct(Product product);
        void DeleteProduct(string keyName);
        bool IsProductAvailable(string name);
        Product GetProduct(string keyName);
        void UpdateProduct(string keyName, Product product);
        string ToString();
        List<Product> GetAllProducts();
    }
}