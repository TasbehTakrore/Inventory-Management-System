using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Inventory
{
    internal class InventorySeeder
    {
        private readonly IInventory _inventory;

        public InventorySeeder(IInventory inventory)
        {
            _inventory = inventory;
        }

        internal void SeedInventory()
        {
            _inventory.AddProduct(new Product { Name = "table", Price = 60, Quantity = 164 });
            _inventory.AddProduct(new Product { Name = "chair", Price = 50, Quantity = 62 });
            _inventory.AddProduct(new Product { Name = "spoon", Price = 20, Quantity = 104 });
        }
    }
}
