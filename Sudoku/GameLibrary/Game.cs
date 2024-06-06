namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public string PuzzlelUrl { get; }

        public Game(string puzzleUrl) {
            this.PuzzlelUrl = puzzleUrl;
        }

        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }

            // Update the game.
            this.UpdateGame();
        }

        public void EndGame()
        {
            this.Exit = true;
        }

        private void UpdateGame() => this.GameUpdated?.Invoke(this, this);
    }

    public interface IGame
    {
        event EventHandler<Game> GameUpdated;
        bool Exit { get; }
        string PuzzlelUrl { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
