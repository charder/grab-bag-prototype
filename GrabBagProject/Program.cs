using GrabBagProject;
using GrabBagProject.Controllers;
using GrabBagProject.Utilities;

public class Program
{

    public static bool GameLooping = true;
    static Game GameInstance;
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        GameInstance = new Game();
        while (GameLooping) { GameInstance.Loop(); }
    }
}

