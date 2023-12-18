using InventoryManagementSystem;
using InventoryManagementSystem.DB;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

AppSettingsReader appSettingsReader = new(configuration);

//var connectionString = appSettingsReader.GetConnectionString("MSDB");
var connectionString = appSettingsReader.GetConnectionString("MongoDB");

//MSDbManager dbManager = new(connectionString);
MongoDbManager mongoDbManager = new(connectionString, "SimpleInventory");

Inventory inventory = new Inventory(mongoDbManager);
InventorySeeder inventorySeeder = new InventorySeeder(inventory);
inventorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(inventory);
userConsoleInterface.Run();