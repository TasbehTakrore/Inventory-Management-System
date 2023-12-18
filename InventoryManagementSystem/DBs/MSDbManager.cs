using System.Data.SqlClient;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DB
{
    internal class MSDbManager : IDbManager
    {
        private readonly string connectionString;

        public MSDbManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void AddProduct(Product product)
        {
            string insertQuery = @"INSERT INTO Products (Name, Price, Quantity) 
                                   VALUES (@Name, @Price, @Quantity)";

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(string productName)
        {
            string deleteQuery = @"DELETE Products 
                                   WHERE Name = @Name";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsProductAvailable(string productName)
        {
            string selectQuery = @"IF EXISTS (SELECT 1 FROM Products WHERE Name = @Name) 
                                    SELECT 1 
                                  ELSE 
                                    SELECT 0";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void UpdateProduct(string productName, Product product)
        {
            string updateQuery = @"UPDATE Products 
                                   SET Name = @NewName, Price = @NewPrice, Quantity = @NewQuantity 
                                   WHERE Name = @OldName";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                Console.WriteLine(product);
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewName", product.Name);
                    command.Parameters.AddWithValue("@NewPrice", product.Price);
                    command.Parameters.AddWithValue("@NewQuantity", product.Quantity);
                    command.Parameters.AddWithValue("@OldName", productName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Product? GetProduct(string productName)
        {
            string selectQuery = @"SELECT Name,
                                          Price,
                                          Quantity
                                   FROM Products 
                                   WHERE Name = @Name";
            Product? product = null;

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", productName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            product = new Product
                            {
                                Name = reader["Name"].ToString(),
                                Price = (int)reader["Price"],
                                Quantity = (int)reader["Quantity"]
                            };
                        }
                    }
                }
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            string selectQuery = @"SELECT Name,
                                          Price,
                                          Quantity
                                   FROM Products";

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.HasRows && reader.Read())
                        {
                            yield return new Product
                            {
                                Name = reader["Name"].ToString(),
                                Price = (int)reader["Price"],
                                Quantity = (int)reader["Quantity"]
                            };
                        }
                    }
                }
            }
        }
    }
}
