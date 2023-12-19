using InventoryManagementSystem.Enums;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.DB;

namespace InventoryManagementSystem
{
    internal class UserConsoleInterface
    {
        private readonly IRepository _repository;
        static ConsoleColor originalColor = Console.ForegroundColor;
        public UserConsoleInterface(IRepository repository)
        {
            _repository = repository;
        }

        internal void Run()
        {
            while (true)
            {
                PrintMainMenu();
                string userInput = ReadUserInput();
                UserSelection userSelection = ParseSelection(userInput);
                HandleSelection(userSelection);
            }
        }
        internal static void PrintMainMenu()
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("* Enter Your Selection *");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Add: To Add a product.");
            Console.WriteLine("View: To View all products.");
            Console.WriteLine("Update: To Update a product");
            Console.WriteLine("Delete: To Delete a product.");
            Console.WriteLine("Search: To Search for a product");
            Console.WriteLine("Exit: To Exit");
        }
        String ReadUserInput()
        {
            Console.Write("Your selection: ");
            string userInput;
            do
            {
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));
            return userInput.Trim();
        }
        UserSelection ParseSelection(string userInput)
        {
            bool isParsable = Enum.TryParse(userInput, out UserSelection userSelection);
            if (isParsable)
                return userSelection;
            else
                return UserSelection.Invalid;
        }

        // I know I should use some patterns here. :)
        internal void HandleSelection(UserSelection userSelection)
        {
            switch (userSelection)
            {
                case UserSelection.Add:
                    Product newProduct = ReadNewProduct();
                    _repository.AddProduct(newProduct);
                    Utilities.PrintMessage("The product has been added successfully\n\n", MessageType.Success);
                    break;
                case UserSelection.View:
                    ViewAllProducts();
                    break;
                case UserSelection.Update:
                    string name = ReadValidProductName(true);
                    UpdateProduct(name);
                    break;
                case UserSelection.Delete:
                    DeleteProduct();
                    break;
                case UserSelection.Search:
                    SearchProduct();
                    break;
                case UserSelection.Exit:
                    Environment.Exit(0);
                    break;
                case UserSelection.Invalid:
                    Console.WriteLine("Invalid selection. Please try again.\n");
                    break;
            }
        }
        internal Product ReadNewProduct()
        {
            string name = ReadValidProductName(isPreExisting: false);
            int price = ReadValidProductPrice();
            int quantity = ReadValidProductQuantity();

            Product product = new Product { Name = name, Price = price, Quantity = quantity };
            return product;
        }
        string ReadValidProductName(bool isPreExisting)
        {
            string name = string.Empty;

            Utilities.PrintMessage("Enter the product name: ", MessageType.Request);
            name = Console.ReadLine();
            while (IsInvalidProductName(name, isPreExisting))
            {
                Utilities.PrintMessage("## This name is not available.\n", MessageType.Error);
                Utilities.PrintMessage("Enter the product name: ", MessageType.Info);
                name = Console.ReadLine();
            }
            return name;
        }
        bool IsInvalidProductName(string name, bool isPreExisting)
        {
            return string.IsNullOrWhiteSpace(name) || (_repository.IsProductAvailable(name.ToLower()) ^ isPreExisting);
        }
        int ReadValidProductPrice()
        {
            Utilities.PrintMessage("Enter the product price: ", MessageType.Request);
            string userInput = Console.ReadLine();
            while (!IsValidPriceInput(userInput))
            {
                Utilities.PrintMessage("## The value must be valid! \n", MessageType.Error);
                Utilities.PrintMessage("Enter the product price: ", MessageType.Request);
                userInput = Console.ReadLine();
            }
            return int.Parse(userInput);
        }
        bool IsValidPriceInput(string userInput)
        {
            return !string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int price) && price > 0;
        }
        int ReadValidProductQuantity()
        {
            int quantity;
            string userInput;
            Utilities.PrintMessage("Enter the product quantity: ", MessageType.Request);
            userInput = Console.ReadLine();
            while (!IsValidQuantityInput(userInput))
            {
                Utilities.PrintMessage("## The value must be valid! \n", MessageType.Error);
                Utilities.PrintMessage("Enter the product quantity: ", MessageType.Request);
                userInput = Console.ReadLine();
            }
            return int.Parse(userInput);
        }
        bool IsValidQuantityInput(string userInput)
        {
            return !string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int quantity) && quantity >= 0;
        }
        void ViewAllProducts()
        {
            IEnumerable<Product> products = _repository.GetAllProducts();
            foreach (var product in products)
            {
                Utilities.PrintMessage($"{product}\n", MessageType.Info);
            }
        }

        UpdateOption ParseUpdateOption(string userInput)
        {
            bool isParsable = Enum.TryParse(userInput, out UpdateOption updateOption);
            if (isParsable)
                return updateOption;
            else
                return UpdateOption.Invalid;
        }
        void UpdateProduct(string keyName)
        {
            Product product = _repository.GetProduct(keyName);
            string userInput;
            while (true)
            {
                Utilities.PrintMessage($"** {keyName} product: Enter (Name) to update name, (Price) to update price, (Quantity) to update quantity, (Done) to Update and back.\n >> ", MessageType.Info);
                userInput = Console.ReadLine();
                UpdateOption updateOption = ParseUpdateOption(userInput);

                switch (updateOption)
                {
                    case UpdateOption.Name:
                        product.Name = GetNewName();
                        break;
                    case UpdateOption.Price:
                        product.Price = GetNewPrice();
                        break;
                    case UpdateOption.Quantity:
                        product.Quantity = GetNewQuantity();
                        break;
                    case UpdateOption.Done:
                        _repository.UpdateProduct(keyName, product);
                        Utilities.PrintMessage("The product has been updated successfully!\n", MessageType.Success);
                        return;
                    default:
                        Utilities.PrintMessage("Invalid input! Please try again.\n", MessageType.Error);
                        break;
                }
            }
        }

        string GetNewName()
        {
            Utilities.PrintMessage("(new name) ", MessageType.Request);
            string newName = ReadValidProductName(false);
            return newName;
        }

        int GetNewPrice()
        {
            Utilities.PrintMessage("(new price) ", MessageType.Request);
            int newPrice = ReadValidProductPrice();
            return newPrice;
        }

        int GetNewQuantity()
        {
            Utilities.PrintMessage("(new quantity) ", MessageType.Request);

            int newQuantity = ReadValidProductPrice();
            return newQuantity;
        }

        void DeleteProduct()
        {
            string name = ReadValidProductName(true);
            _repository.DeleteProduct(name);
            Utilities.PrintMessage($"The product has been deleted successfully! \n", MessageType.Success);
        }
        void SearchProduct()
        {
            string name = ReadValidProductName(true);
            Product product = _repository.GetProduct(name);
            Utilities.PrintMessage($"{product}\n", MessageType.Info);
        }
    }
}