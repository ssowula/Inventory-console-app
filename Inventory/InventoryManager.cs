using System.Drawing;
using Pastel;

class InventoryManager
{
    private static List<Product> products = new List<Product>();

    public static void AddNewProducts()
    {
        string name = InputValidator.StringValidation(
            "Enter a name of product: ",
            "Name can't be empty. Please try again.".Pastel(Color.Red)
        );

        double price = InputValidator.DoubleValidation(
            "Enter a price of product: ",
            "Invalid price format. Please try again.".Pastel(Color.Red)
        );

        int quantity = InputValidator.IntValidation(
            "Enter a quantity of product: ",
            "Invalid quantity format. Please enter a whole number.".Pastel(Color.Red)
        );

        Product newProduct = new Product(name, price, quantity);
        products.Add(newProduct);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
    public static void ShowAllProducts()
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
    public static void UpdateProducts()
    {
        ShowAllProducts();
        int len = products.Count;
        int id = InputValidator.IdAndChoiceValidation(
            "Enter an Id of product you want to update: ",
            "A product with that ID does not exist. Please try again.".Pastel(Color.Red),
            len
        );

        Console.WriteLine("What do you want to update?");
        Console.WriteLine("1. Name\n2. Price \n3. Quantity");
        int choice = InputValidator.IdAndChoiceValidation(
            "Select an option: ",
            "There is no option with this number. Please try again.".Pastel(Color.Red),
            3
        );

        Product updateProduct = products[id - 1];

        switch (choice)
        {
            case 1:
                string newName = InputValidator.StringValidation(
                    "Enter new product name: ",
                    "Wrong name. Please try again.".Pastel(Color.Red)
                );
                updateProduct.Name = newName;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
                break;
            case 2:
                double newPrice = InputValidator.DoubleValidation(
                    "Enter new product price: ",
                    "Wrong price. Please try again.".Pastel(Color.Red)
                );

                updateProduct.Price = newPrice;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
                break;
            case 3:
                int newQuantity = InputValidator.IntValidation(
                   "Enter new product quantity: ",
                   "Wrong quantity. Please try again.".Pastel(Color.Red)
                );
                updateProduct.Quantity = newQuantity;
                Console.WriteLine("Success".Pastel(Color.LightGreen));
                break;
        }
    }
    public static void DeleteProducts()
    {
        ShowAllProducts();
        int len = products.Count;
        int id = InputValidator.IdAndChoiceValidation(
            "Enter the ID of the product to delete: ",
            "A product with that ID does not exist. Please try again.".Pastel(Color.Red),
            len
        );

        products.RemoveAt(id - 1);
        Console.WriteLine("Success".Pastel(Color.LightGreen));
    }
}
