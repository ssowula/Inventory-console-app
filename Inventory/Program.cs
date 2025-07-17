class Inventory
{
    public static List<string> Products = new List<string>();
    public static List<double> Price = new List<double>();
    public static List<int> Quantity = new List<int>();
    int len = Products.Count;
    public static void addNewProducts()
    {
        Console.WriteLine("Enter a name of product");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name can't be empty");
            return;
        }
        double price;
        Console.WriteLine("Enter a price of product");
        if (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("You need to enter a double type");
            return;
        }
        int quantity;
        Console.WriteLine("Enter a quantity of product");
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("You need to enter a int type");
            return;
        }
        Products.Add(name);
        Price.Add(price);
        Quantity.Add(quantity);
        Console.WriteLine("Succsess");
    }
    public static void showAllProducts()
    {
        int len = Products.Count;
        if (len == 0)
        {
            Console.WriteLine("You have 0 products in your Inventory");
        }
        else
        {
            Console.WriteLine("Id. Name - Price - Quantity");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i]} - {Price[i]} - {Quantity[i]}");
            }
        }
    }
     public static void updateProducts()
    {
        int len = Products.Count;
        Console.WriteLine("Enter an Id of product you want to update: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("You need to enter an intiger");
            return;
        }
        if (id > len + 1)
        {
            Console.WriteLine("We dont have that many products");
            return;
        }
        else if (id <= 0)
        {
            Console.WriteLine("Id must be highier than 0");
            return;
        }
        Console.WriteLine("What do you want to update?");
        Console.WriteLine("1. Name\n2. Price \n3. Quantity");
        int pick;
        if (!int.TryParse(Console.ReadLine(), out pick))
        {
            Console.WriteLine("You need to enter an intiger");
            return;
        }
        if (pick == 1)
        {
            Console.WriteLine("Please enter new name for this product");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Wrong name");
                return;
            }
            else
            {
                Products[id - 1] = newName;
                Console.WriteLine("Succsess");
            }
        }
        else if (pick == 2)
        {
            Console.WriteLine("Please enter new price for this product");
            double newPrice;
            if (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("Wrong price");
                return;
            }
            else
            {
                Price[id - 1] = newPrice;
                Console.WriteLine("Succsess");
            }
        }
        else if (pick == 3)
        {
            Console.WriteLine("Please enter new quantity for this product");
            int newQuantity;
            if (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine("Wrong quantity");
                return;
            }
            else
            {
                Quantity[id - 1] = newQuantity;
                Console.WriteLine("Succsess");
            }
        }
        else
        {
            Console.WriteLine("There is no option with this number");
            return;
        }
    }
}