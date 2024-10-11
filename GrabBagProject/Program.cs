using GrabBagProject.Controllers;
using GrabBagProject.Utilities;

public class Program
{
    Controller activeController;
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("What is your name?");
        string? input = null;
        while (input == null || input.ToLowerInvariant() != "quit")
        {
            input = Console.ReadLine();
        }
    }
}

