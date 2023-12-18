using InventoryManagementSystem;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

AppSettingsReader appSettingsReader = new(configuration);

Console.WriteLine(appSettingsReader.GetConnectionString("MSDB"));
Inventory inventory = new Inventory();
InventorySeeder inventorySeeder = new InventorySeeder(inventory);
inventorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(inventory);
userConsoleInterface.Run();