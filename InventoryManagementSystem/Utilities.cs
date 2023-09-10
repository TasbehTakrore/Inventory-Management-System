using System;
using InventoryManagementSystem;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Diagnostics;

namespace InventoryManagementSystem
{
    internal class Utilities
    {
        static Inventory inventory = new Inventory();
        static string? userSelection;
        static ConsoleColor originalColor = Console.ForegroundColor;

        internal static void Initilization()
        {
            inventory.AddProduct("table", 60, 164);
            inventory.AddProduct("chair", 38, 166);
            inventory.AddProduct("spoon", 8, 262);
        }
        internal static void ShowMainMenu()
         {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("-------------------------");

            Console.WriteLine("A: Add a product.");
            Console.WriteLine("V: View all products.");
            Console.WriteLine("E: Edit a product");
            Console.WriteLine("D: Delete a product.");
            Console.WriteLine("S: Search for a product");
            Console.WriteLine("X: Exit");

            HandleUserSelections();
      

        }
      static void HandleUserSelections()
        {
            while (true)
            {
                Console.Write("Your selection: ");
                userSelection = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userSelection))
                {
                    switch (userSelection.ToLower())
                    {
                        case "a":
                            AddProductProcess();
                            break;
                        case "v":
                            ViewallProductsProcess();
                            break;
                        case "e":
                            SelectProductProcess();
                            break;
                        case "d":
                            DeleteProductProcess();
                            break;
                        case "s":
                            SearchProductProcess();
                            break;
                        case "x":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please try again.");
                }
            }
        }

        internal static void AddProductProcess()
        {
            string result;
            string name;
            int price;
            int quantity;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n* Adding new Product *");
            Console.ForegroundColor = originalColor;

            name = ReadProductName(false); // isPreExisting? => false  
            price = ReadProductPrice(); ;
            quantity = ReadProductQuantity();

            result = inventory.AddProduct(name, price, quantity);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;
            ShowMainMenu();


        }

        static string ReadProductName(bool isPreExisting) {

            string name = string.Empty;

            Console.Write("Enter the product name: ");
            name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name) || !(inventory.IsAvailableName(name.ToLower()) ^ isPreExisting)) // XNOR operation
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("## This name is not available.\n");
                Console.ForegroundColor = originalColor;
                Console.Write("Enter the product name: ");
                name = Console.ReadLine();

            }
            return name;

        }


        static int ReadProductPrice()
        {
            int price;
            string userInput;

            Console.Write("Enter the product price: ");
            userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("## The value must be valid! \n");
                Console.ForegroundColor = originalColor;
                Console.Write("Enter the product price: ");

                userInput = Console.ReadLine();
            }
            return price;

        }

        static int ReadProductQuantity()
        {
            int quantity;
            string userInput;
            Console.Write("Enter the product quantity: ");
            userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("## The value must be valid! \n");
                Console.ForegroundColor = originalColor; Console.Write("Enter the product quantity: ");

                userInput = Console.ReadLine();
            }
            return quantity;

        }
        static void ViewallProductsProcess() 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n* Viewing All Products *");
            Console.ForegroundColor = originalColor;
            Console.Write(inventory);
            Console.WriteLine();
            ShowMainMenu();

        }
        static void SelectProductProcess()
        {
            string name;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n* Edit a Product *");
            Console.ForegroundColor = originalColor;

            name = ReadProductName(true); // isPreExisting? => true
            EditProductProcess(name);

        }

        static void EditProductProcess(string name) 
        {
            string userInput;

            while (true)
            {
                Console.WriteLine($"** {name} product: Enter (N) to update name, (P) to update price, (Q) to update quantity, (#) to back.");
                userInput = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    switch (userInput.ToLower())
                    {
                        case "n":
                            name =  EditName(name);
                            break;
                        case "p":
                            EditPrice(name);
                            break;
                        case "q":
                            EditQuantity(name);
                            break;
                        case "#":
                            ShowMainMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid input! Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please try again.");
                }
            }

        }

        static string EditName(string keyName) 
        {
            string newName;
            string result;
            Console.Write("(new name) ");
            newName = ReadProductName(false);
            result = inventory.EditProductName(keyName , newName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;
            return newName;

        }

        static void EditPrice(string keyName) 
        {
            int newPrice;
            string result;
            Console.Write("(new price) ");

            newPrice = ReadProductPrice();
            result = inventory.EditProductPrice(keyName, newPrice);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;
        }

        static void EditQuantity(string keyName)
        {
            int newQuantity;
            string result;
            Console.Write("(new quantity) ");

            newQuantity = ReadProductPrice();
            result = inventory.EditProductQuantity(keyName, newQuantity);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;

        }

        static void DeleteProductProcess() 
        {
            string name;
            string result;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n* Delet a Product *");
            Console.ForegroundColor = originalColor;

            name = ReadProductName(true);
            result = inventory.DeleteProduct(name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;
            ShowMainMenu();
        }
        static void SearchProductProcess() 
        {
            string name;
            string result;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n* Search for a product *");
            Console.ForegroundColor = originalColor;

            name = ReadProductName(true);
            result = inventory.SearchProduct(name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result + "\n\n");
            Console.ForegroundColor = originalColor;
            ShowMainMenu();

        }


    }
}
