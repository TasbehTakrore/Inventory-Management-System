using Microsoft.Extensions.Configuration;

namespace InventoryManagementSystem
{
    public class AppSettingsReader
    {
        private readonly IConfiguration _configuration;
        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString(string key)
        {
            var connectionString = _configuration.GetConnectionString(key);
            if (connectionString == null)
            {
                throw new Exception($"No Connection String found for key '{key}'");
            }
            return connectionString;
        }
    }
}