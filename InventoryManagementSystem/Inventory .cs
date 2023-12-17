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
<<<<<<< HEAD

        public string EditProductName(string keyName, string newName) 
        {
            products[keyName].Name = newName;
            Product updatedProduct = products[keyName];

            products.Remove(keyName);
            products.Add(newName, updatedProduct);

            return $"The product name has been modified successfully! [Previous Name: {keyName}, New Name: {newName}] \n";
        }        
        
        public string EditProductPrice(string keyName, int newPrice) 
        {

            products[keyName].Price = newPrice;
            return $"The {keyName} price has been modified successfully! \n";
        }
        public string EditProductQuantity(string keyName, int newQuantity) 
        {

            products[keyName].Quantity = newQuantity;
            return $"The {keyName} quantity has been modified successfully! \n";
        }
        public string DeleteProduct(string keyName) 
        {
            products.Remove(keyName);
            return $"The {keyName} product has been deleted successfully! \n";
        }
        public string SearchProduct(string keyName) 
        {
            return $"{products[keyName]}";
        }



        public override string ToString()
        {
            String allProducts = string.Empty;
            foreach (var item in products) {
                allProducts += $"{item.Value}\n";
                
            }
            return allProducts;
        }
=======
>>>>>>> 333e038 (Add feature to add a new product to the inventory)
    }
}
