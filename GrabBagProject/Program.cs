using GrabBagProject;

public class Program
{

    public static bool RestartGame = true;
    public static bool GameLooping = true;
    static Game GameInstance;
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        while (RestartGame)
        {
            RestartGame = false;
            GameLooping = true;
            GameInstance = new Game();
            while (GameLooping) { GameInstance.Loop(); }
        }
    }
}

