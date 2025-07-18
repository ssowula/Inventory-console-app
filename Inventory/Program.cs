using System.Drawing;
using Pastel;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
class Inventory
{
    public static List<Product> products = new List<Product>();

    public static string stringValidation(string prompt, string error)
    {
        string? value;
        while (true)
        {
            Console.Write($"{prompt}");
            value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine($"{error}");
                continue;
            }
            else
            {
                break;
            }
        }
        return value;
    }

    public static int intValidation(string prompt, string error)
    {
        int value;
        while (true)
        {
            Console.Write($"{prompt}");
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine($"{error}");
                continue;
            }
            else if (value < 0)
            {
                Console.WriteLine("Please enter non-negative number");
                continue;
            }
            else
            {
                break;
            }
        }
        return value;
    }

    public static double doubleValidation(string prompt, string error)
    {
        double value;
        while (true)
        {
            Console.Write($"{prompt}");
            if (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine(error);
                continue;
            }
            else if (value < 0)
            {
                Console.WriteLine("Please enter non-negative number");
                continue;
            }
            else
            {
                break;
            }
        }
        return value;
    }

    public static int idAndChoiceValidation(string prompt, string error, int max)
    {
        int value;
        while (true)
        {
            Console.Write($"{prompt}");
            if (!int.TryParse(Console.ReadLine(), out value) || value > max || value <= 0)
            {
                Console.WriteLine($"{error}");
                continue;
            }
            else
            {
                break;
            }
        }
        return value;
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("INVENTORY MENU".Pastel(Color.Yellow));
            Console.WriteLine("1. Add product\n2. Update product\n3. Delete product\n4. Show all products\n5. Exit");
            Console.Write("Select an option: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a number");
                continue;
            }
            switch (choice)
            {
                case 1:
                    addNewProducts();
                    break;
                case 2:
                    updateProducts();
                    break;
                case 3:
                    deleteProducts();
                    break;
                case 4:
                    showAllProducts();
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

    public static void addNewProducts()
    {
        string name = stringValidation(
            "Enter a name of product: ",
            "Name can't be empty. Please try again.".Pastel(Color.Red)
        );

        double price = doubleValidation(
            "Enter a price of product: ",
            "Invalid price format. Please try again.".Pastel(Color.Red)
        );
       
        int quantity = intValidation(
            "Enter a quantity of product: ",
            "Invalid quantity format. Please enter a whole number.".Pastel(Color.Red)
        );
        
        Product newProduct = new Product(name, price, quantity); 
        products.Add(newProduct);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
    public static void showAllProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Inventory is empty".Pastel(Color.Orange));
            return;
        }
        Console.WriteLine("Id. Name - Price - Quantity".Pastel(Color.LightBlue));
        for (int i = 0; i < products.Count; i++)
        {
            Product p = products[i]; 
            Console.WriteLine($"{i + 1}. {p.Name} - {p.Price:F2} - {p.Quantity}");        
        }
        
    }
    public static void updateProducts()
    {
        showAllProducts();
        int len = products.Count;
        int id = idAndChoiceValidation(
            "Enter an Id of product you want to update: ",
            "A product with that ID does not exist. Please try again.".Pastel(Color.Red),
            len
        );

        Console.WriteLine("What do you want to update?");
        Console.WriteLine("1. Name\n2. Price \n3. Quantity");
        int choice = idAndChoiceValidation(
            "Select an option: ",
            "There is no option with this number. Please try again.".Pastel(Color.Red),
            3
        );

        Product updateProduct = products[id - 1];
        if (choice == 1)
        {
            string newName = stringValidation(
                "Enter new product name: ",
                "Wrong name. Please try again.".Pastel(Color.Red)
            );
            updateProduct.Name = newName;
            Console.WriteLine("Success".Pastel(Color.LightGreen));
        }
        else if (choice == 2)
        {
            double newPrice = doubleValidation(
                "Enter new product price: ",
                "Wrong price. Please try again.".Pastel(Color.Red)
            );
        
            updateProduct.Price = newPrice;
            Console.WriteLine("Success".Pastel(Color.LightGreen));
        }
        else if (choice == 3)
        {
            int newQuantity = intValidation(
                "Enter new product quantity: ",
                "Wrong quantity. Please try again.".Pastel(Color.Red)
            );
            updateProduct.Quantity = newQuantity;
            Console.WriteLine("Success".Pastel(Color.LightGreen));
        }
    }
    public static void deleteProducts()
    {
        showAllProducts();
        int len = products.Count;
        int id = idAndChoiceValidation(
            "Enter the ID of the product to delete: ",
            "A product with that ID does not exist. Please try again.".Pastel(Color.Red),
            len
        );

        products.RemoveAt(id - 1);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
}