using InventoryManagementSystem;

Inventory inventory = new Inventory();
InventorySeeder inventorySeeder = new InventorySeeder(inventory);
inventorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(inventory);
userConsoleInterface.Run();