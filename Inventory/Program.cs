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
}