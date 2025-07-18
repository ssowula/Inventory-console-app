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
            Console.WriteLine("Pick an action: ");
            Console.WriteLine("1. Add product\n2. Update product\n3. Delete product\n4. Show all products\n5. Exit");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("You need to select proper action");
                return;
            }
            if (choice > 5 || choice < 0)
            {
                Console.WriteLine("Wrong number".Pastel(Color.Red));
                return;
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
            }
        }
    }

    public static void addNewProducts()
    {
        Console.WriteLine("Enter a name of product");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name can't be empty".Pastel(Color.Red));
            return;
        }
        double price;
        Console.WriteLine("Enter a price of product");
        if (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("You need to enter a double type".Pastel(Color.Red));
            return;
        }
        int quantity;
        Console.WriteLine("Enter a quantity of product");
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("You need to enter a int type".Pastel(Color.Red));
            return;
        }
        Product newProduct = new Product(name, price, quantity); //tworzymy zmienną typu Product o nazwie "newProduct" i przypisujemy jej wpisane przez użytkownika dane
        products.Add(newProduct);
        Console.WriteLine("Succsess".Pastel(Color.LightGreen));
    }
    public static void showAllProducts()
    {
        int len = products.Count;
        if (len == 0)
        {
            Console.WriteLine("You have 0 products in your Inventory");
        }
        else
        {
            Console.WriteLine("Id. Name - Price - Quantity".Pastel(Color.LightBlue));
            for (int i = 0; i < len; i++)
            {
                Product p = products[i]; //tworzymy zmienną typu product o nazwie "p" i przypisujemy jej i-ty obiekt (produkt)
                Console.WriteLine($"{i+1}. {p.Name} - {p.Price} - {p.Quantity}");
            }
        }
    }
    public static void updateProducts()
    {
        int len = products.Count;
        if (len == 0)
        {
            Console.WriteLine("You have 0 products in your Inventory");
            return;
        }
        showAllProducts();
        Console.WriteLine("Enter an Id of product you want to update: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("You need to enter an intiger".Pastel(Color.Red));
            return;
        }
        if (id > len + 1)
        {
            Console.WriteLine("We dont have that many products".Pastel(Color.Red));
            return;
        }
        else if (id <= 0)
        {
            Console.WriteLine("Id must be highier than 0".Pastel(Color.Red));
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
            Console.WriteLine("Please enter new name for this product");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Wrong name".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Name = newName;
                Console.WriteLine("Succsess".Pastel(Color.LightGreen));
            }
        }
        else if (pick == 2)
        {
            Console.WriteLine("Please enter new price for this product");
            double newPrice;
            if (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Wrong price".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Price = newPrice;
                Console.WriteLine("Succsess".Pastel(Color.LightGreen));
            }
        }
        else if (pick == 3)
        {
            Console.WriteLine("Please enter new quantity for this product");
            int newQuantity;
            if (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine("Wrong quantity".Pastel(Color.Red));
                return;
            }
            else
            {
                updateProduct.Quantity = newQuantity;
                Console.WriteLine("Succsess".Pastel(Color.LightGreen));
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
        int len = products.Count;
        if (len == 0)
        {
            Console.WriteLine("You have 0 products in your Inventory");
            return;
        }
        else
        {
            showAllProducts();
        }
        Console.WriteLine("Enter an Id of product you wanna delete: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("You need to enter an intiger".Pastel(Color.Red));
            return;
        }
        if (id > len + 1)
        {
            Console.WriteLine("We dont have that many products".Pastel(Color.Red));
            return;
        }
        else if (id <= 0)
        {
            Console.WriteLine("Id must be highier than 0".Pastel(Color.Red));
            return;
        }
        products.RemoveAt(id - 1);
        Console.WriteLine("Succsess".Pastel(Color.LightGreen));
    }
}