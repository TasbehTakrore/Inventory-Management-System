using InventoryManagementSystem.Models;
using MongoDB.Driver;

namespace InventoryManagementSystem.DB
{
    internal class MongoDbManager : IDbManager
    {
        private readonly IMongoDatabase _database;
        public MongoDbManager(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(dbName);
        }
        public void AddProduct(Product product)
        {
            var collection = _database.GetCollection<Product>("Products");
            collection.InsertOne(product);
        }

        public void DeleteProduct(string productName)
        {
            var collection = _database.GetCollection<Product>("Products");
            collection.DeleteOne(product => product.Name == productName);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var collection = _database.GetCollection<Product>("Products");

            var fieldsBuilder = Builders<Product>.Projection;
            var fields = fieldsBuilder.Exclude("_id");

            return collection.Find(_ => true).Project<Product>(fields).ToEnumerable();
        }

        public Product? GetProduct(string productName)
        {
            var collection = _database.GetCollection<Product>("Products");

            var fieldsBuilder = Builders<Product>.Projection;
            var fields = fieldsBuilder.Exclude("_id");

            return collection.Find(product => product.Name == productName)
               .Project<Product>(fields).FirstOrDefault();
        }

        public bool IsProductAvailable(string productName)
        {
            var collection = _database.GetCollection<Product>("Products");

            return collection.Find(product => product.Name == productName).Any();
        }

        public void UpdateProduct(string productName, Product product)
        {
            var collection = _database.GetCollection<Product>("Products");

            collection.ReplaceOne(product => product.Name == productName, product);
        }
    }
}
