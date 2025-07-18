using System.Drawing;
using Pastel;
class Menu
{
    private static void ShowMenu()
    {
        Console.WriteLine("INVENTORY MENU".Pastel(Color.Yellow));
        Console.WriteLine("1. Add product\n2. Update product\n3. Delete product\n4. Show all products\n5. Exit");
        Console.Write("Select an option: ");
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number");
                continue;
            }
            switch (choice)
            {
                case 1:
                    InventoryManager.AddNewProducts();
                    break;
                case 2:
                    InventoryManager.UpdateProducts();
                    break;
                case 3:
                    InventoryManager.DeleteProducts();
                    break;
                case 4:
                    InventoryManager.ShowAllProducts();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.".Pastel(Color.Red));
                    break;
            }
            Console.WriteLine("\nPress any key to return to the menu...".Pastel(Color.Gray));
            Console.ReadKey();
            Console.Clear();
        }
    }

}