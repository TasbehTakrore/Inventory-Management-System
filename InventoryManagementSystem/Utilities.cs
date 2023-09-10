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

        }
        internal static void ShowMainMenu()
         {
            Console.WriteLine("-------------------------");
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
                    userSelection = userSelection.ToLower();
                    switch (userSelection)
                    {
                        case "a":
                            AddProductProcess();
                            break;
                        case "v":
                            ViewallProductsProcess();
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


    }
}
