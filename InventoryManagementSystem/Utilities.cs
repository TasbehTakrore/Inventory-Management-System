
using InventoryManagementSystem.Enums;

namespace InventoryManagementSystem
{
    internal class Utilities
    {
        internal static void PrintMessage(string message, MessageType messageType)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            switch (messageType)
            {
                case MessageType.Info | MessageType.Request:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.Write($"{message}");
            Console.ForegroundColor = originalColor;
        }
    }
}
