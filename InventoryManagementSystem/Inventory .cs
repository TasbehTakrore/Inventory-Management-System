using System;

namespace InventoryManagementSystem
{
    internal class Inventory
    {
        Dictionary<string, Product> products = new Dictionary<string, Product>();


        public string AddProduct(string name, int price, int quantity)
        {
            products.Add(name.ToLower(),new Product(name, price, quantity));
            return "Adding the new product succeeded!";

        }
        public bool IsAvailableName(string name)
        {
            return !products.ContainsKey(name);
        }
    }
}
