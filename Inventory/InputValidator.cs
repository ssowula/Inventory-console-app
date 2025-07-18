class InputValidator
{
    public static string StringValidation(string prompt, string error)
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

    public static int IntValidation(string prompt, string error)
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

    public static double DoubleValidation(string prompt, string error)
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

    public static int IdAndChoiceValidation(string prompt, string error, int max)
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
}