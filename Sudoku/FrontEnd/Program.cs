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
                IGame game = Creator.Create();

                Display display = new();

                // Event handler 'that checks for game updates.

                // As long as the game is not completed, wait for the next user input.


                Console.WriteLine("Press any key to restart the game...");
                Console.ReadKey();
            }
        }
    }
}
