namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public Game() {}

        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }
        }

        public void EndGame()
        {
            this.Exit = true;
        }
    }

    public interface IGame
    {
        event EventHandler<Game> GameUpdated;
        bool Exit { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
