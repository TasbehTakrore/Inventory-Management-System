namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"* Name: {Name},  Price:  {Price}, Quantity:  {Quantity}";
        }
    }
}
