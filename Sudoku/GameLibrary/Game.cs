using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public ISudoku Sudoku { get; }

        public IPlayer Player { get; }

        public Game(ISudoku sudoku) {
            this.Sudoku = sudoku;
            this.Player = new Player(this.Sudoku);
        }

        // This function gets called after the game registers a new user input.
        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }

            // For optimalisation. If none of the input modes are given we don not have to update the game.
            if (input.Move is null && input.Value is null && !input.ToggleViewMode && !input.ToggleIndicationMode)
            {
                return;
            }

            if (input.ToggleViewMode)
            {
                this.Sudoku.ViewType = this.Sudoku.ViewType == ViewType.Definite ? ViewType.Note : ViewType.Definite;
                input.ToggleViewMode = false;
            }

            if (input.ToggleIndicationMode)
            {
                this.Sudoku.ValidationMode = !this.Sudoku.ValidationMode;
                input.ToggleIndicationMode = false;
            }

            if (input.Move is not null)
            {
                // Move the Player.
                if (!this.Player.Move(input.Move.Value, this.Sudoku))
                {
                    return;
                }   
            }

            if (input.Value is not null)
            {
                // Update the Cell data.
                if (!this.Player.UpdateCellValue(input.Value.Value, this.Sudoku.ViewType))
                {
                    return;
                }
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
        ISudoku Sudoku { get; }
        event EventHandler<Game> GameUpdated;
        bool Exit { get; }
        IPlayer Player { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
