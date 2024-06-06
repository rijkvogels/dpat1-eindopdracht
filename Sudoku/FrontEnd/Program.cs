using DataTransfer;
using GameLibrary;

namespace FrontEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IGame game = Parser.Create();

                Display display = new();
                display.UpdateGame(game);

                // Event handler 'that checks for game updates.
                game.GameUpdated += (eSender, eGame) => display.UpdateGame(eGame);

                // As long as the game is not completed, wait for the next input.
                while (!game.Exit)
                {
                    ConsoleKey nextInput = Console.ReadKey().Key;
                    game.NextFrame(Input.GetDirection(nextInput));
                }

                Console.WriteLine("Press any key to restart the game...");
                Console.ReadKey();
            }
        }
    }
}
