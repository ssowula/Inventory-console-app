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
    public static void Main(string[] args)
    {
        bool show = true;
        while (show)
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
        }
    }

    public static void addNewProducts()
    {
        Console.Write("Enter a name of product: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name can't be empty".Pastel(Color.Red));
            return;
        }
        double price;
        Console.Write("Enter a price of product: ");
        if (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price format. Please enter a number.".Pastel(Color.Red));
            return;
        }
        int quantity;
        Console.Write("Enter a quantity of product: ");
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid quantity format. Please enter a whole number.".Pastel(Color.Red));
            return;
        }
        Product newProduct = new Product(name, price, quantity); //tworzymy zmienną typu Product o nazwie "newProduct" i przypisujemy jej wpisane przez użytkownika dane
        products.Add(newProduct);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
    public static void showAllProducts()
    {
        int len = products.Count;
        if (len == 0)
        {
            Console.WriteLine("Inventory is empty".Pastel(Color.Orange));
            return;
        }
        else
        {
            Console.WriteLine("Id. Name - Price - Quantity".Pastel(Color.LightBlue));
            for (int i = 0; i < len; i++)
            {
                Product p = products[i]; //tworzymy zmienną typu product o nazwie "p" i przypisujemy jej i-ty obiekt (produkt)
                Console.WriteLine($"{i + 1}. {p.Name} - {p.Price} - {p.Quantity}");
            }
        }
    }
    public static void updateProducts()
    {
        showAllProducts();
        int len = products.Count;
        Console.Write("Enter an Id of product you want to update: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a number".Pastel(Color.Red));
            return;
        }
         if (id > products.Count || id <= 0)
        {
            Console.WriteLine("A product with that ID does not exist.".Pastel(Color.Red));
            return;
        }
        Console.WriteLine("What do you want to update?");
        Console.WriteLine("1. Name\n2. Price \n3. Quantity");
        int pick;
        if (!int.TryParse(Console.ReadLine(), out pick))
        {
            Console.WriteLine("You need to enter an intiger".Pastel(Color.Red));
            return;
        }
        Product updateProduct = products[id - 1];
        if (pick == 1)
        {
            Console.Write("Enter new product name: ");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Wrong name".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Name = newName;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
            }
        }
        else if (pick == 2)
        {
            Console.Write("Enter new product price: ");
            double newPrice;
            if (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Wrong price".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Price = newPrice;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
            }
        }
        else if (pick == 3)
        {
            Console.Write("Please new product quantity: ");
            int newQuantity;
            if (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine("Wrong quantity".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Quantity = newQuantity;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
            }
        }
        else
        {
            Console.WriteLine("There is no option with this number".Pastel(Color.Red));
            return;
        }
    }
    public static void deleteProducts()
    {
        showAllProducts();
        int len = products.Count;
        Console.Write("Enter the ID of the product to delete: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("You need to enter an intiger".Pastel(Color.Red));
            return;
        }
        if (id > products.Count || id <= 0)
        {
            Console.WriteLine("A product with that ID does not exist.".Pastel(Color.Red));
            return;
        }
        products.RemoveAt(id - 1);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
}