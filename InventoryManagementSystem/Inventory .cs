
namespace InventoryManagementSystem
{
    internal class Inventory : IInventory
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void AddProduct(Product product)
        {
            products.Add(product.Name.ToLower(), product);
        }
        public bool IsProductAvailable(string name)
        {
            return products.ContainsKey(name);
        }
        public void UpdateProduct(string keyName, Product product)
        {
            products[keyName] = product;
            if (!keyName.Equals(product.Name))
            {
                products.Remove(keyName);
                products.Add(product.Name, product);
            }
        }
        public void DeleteProduct(string keyName)
        {
            products.Remove(keyName);
        }

        public Product GetProduct(string keyName)
        {
            return products[keyName];
        }
        public List<Product> GetAllProducts()
        {
            return products.Values.ToList();
        }
    }
}
