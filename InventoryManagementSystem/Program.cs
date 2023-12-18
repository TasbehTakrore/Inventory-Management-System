using InventoryManagementSystem;
using InventoryManagementSystem.DB;
using InventoryManagementSystem.Inventory;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

AppSettingsReader appSettingsReader = new(configuration);

// Uncomment the following code to use Microsoft SQL Server database instead of MongoDB
/*
var connectionString = appSettingsReader.GetConnectionString("MSDB");
MSDbManager dbManager = new(connectionString);
*/

// Uncomment the following code to use MongoDB database
var connectionString = appSettingsReader.GetConnectionString("MongoDB");
MongoDbManager dbManager = new(connectionString, "SimpleInventory");


Inventory inventory = new Inventory(dbManager);
InventorySeeder inventorySeeder = new InventorySeeder(inventory);
inventorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(inventory);
userConsoleInterface.Run();