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
/*var connectionString = appSettingsReader.GetConnectionString("SqlDB");
SqlRepository repository = new(connectionString);*/


// Uncomment the following code to use MongoDB database
var connectionString = appSettingsReader.GetConnectionString("MongoDB");
IRepository repository = new MongoRepository(connectionString, "SimpleInventory");

RepositorySeeder repositorySeeder = new RepositorySeeder(repository);
repositorySeeder.SeedInventory();
UserConsoleInterface userConsoleInterface = new(repository);
userConsoleInterface.Run();