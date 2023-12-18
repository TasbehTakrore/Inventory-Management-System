# Inventory-Management-System

## Overview

The **Inventory Management System** is a console-based application written in C# that enables users to manage a product inventory. The system supports various operations, including adding, viewing, updating, and deleting products, as well as searching for products. It provides flexibility by allowing users to choose either Microsoft SQL Server or MongoDB as the backend database.

## Features

- **Add Product:** Add a new product to the inventory with a specified name, price, and quantity.

- **View Products:** Display a list of all products in the inventory.

- **Update Product:** Modify the details of an existing product, including name, price, and quantity.

- **Delete Product:** Remove a product from the inventory.

- **Search Product:** Find a specific product by name and view its details.

- **Database Support:** Choose between Microsoft SQL Server or MongoDB as the backend database.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (if using MongoDB as the database)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (if using SQL Server as the database)


### Installation

1. **Clone the repository:**

   ```git clone https://github.com/your-username/inventory-management-system.git```
   
2. **Navigate to the project directory:**

   ```cd inventory-management-system```
   
3. **Build the project:**
    ```dotnet build```

4. **Run the application:**
    ```dotnet run```

### Configuration
The application reads its configuration from the appsettings.json file. Customize database connection strings and other settings in this file.
```json
{
  "ConnectionStrings": {
    "MSDB": "Data Source=TASBEH-TAKRORE;Initial Catalog=SimpleInventory;Integrated Security=True",
    "MongoDB": "mongodb://localhost:27017"
  }
}
```

### Usage

* Run the application and follow the on-screen instructions to perform various inventory management tasks.

* Choose the database type by uncommenting the corresponding code block in the Program.cs file.

### FlowChart

![Untitled-2023-09-04-1719](https://github.com/TasbehTakrore/Inventory-Management-System/assets/71009816/0e597b89-7143-47b1-92ee-c690c970e99e)
