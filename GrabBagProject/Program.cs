using GrabBagProject;

public class Program
{

    public static bool RestartGame = true;
    public static bool GameLooping = true;
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        while (RestartGame)
        {
            RestartGame = false;
            GameLooping = true;
            Game game = Game.Instance = new Game();
            while (GameLooping) { game.Loop(); }
        }
    }
}

