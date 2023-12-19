using InventoryManagementSystem.DB;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Inventory
{
    internal class RepositorySeeder
    {
        private readonly IRepository _repository;

        public RepositorySeeder(IRepository repository)
        {
            _repository = repository;
        }

        internal void SeedInventory()
        {
            _repository.AddProduct(new Product { Name = "table", Price = 60, Quantity = 164 });
            _repository.AddProduct(new Product { Name = "chair", Price = 50, Quantity = 62 });
            _repository.AddProduct(new Product { Name = "spoon", Price = 20, Quantity = 104 });
        }
    }
}
