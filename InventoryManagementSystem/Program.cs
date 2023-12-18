using InventoryManagementSystem;
using InventoryManagementSystem.DB;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

AppSettingsReader appSettingsReader = new(configuration);

var connectionString = appSettingsReader.GetConnectionString("MSDB");
MSDbManager dbManager = new(connectionString);

Inventory inventory = new Inventory(dbManager);
InventorySeeder inventorySeeder = new InventorySeeder(inventory);
inventorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(inventory);
userConsoleInterface.Run();