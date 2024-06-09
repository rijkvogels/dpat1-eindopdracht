using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public ISudoku Sudoku { get; }
        
        public SudokuType SudokuType { get; }

        public Game(ISudoku sudoku, SudokuType sudokuType) {
            this.Sudoku = sudoku;
            this.SudokuType = sudokuType;
        }

        // This function gets called after the game registers a new user input.
        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }

            if (input.ToggleViewMode)
            {
                this.Sudoku.ViewType = this.Sudoku.ViewType == ViewType.Definite ? ViewType.Note : ViewType.Definite;
                input.ToggleViewMode = false;
            }

            if (input.ToggleIndicationMode)
            {
                this.Sudoku.IndicationMode = !this.Sudoku.IndicationMode;
                input.ToggleIndicationMode = false;
            }

            if (input.Move is not null)
            {
                // TODO: Handle the game logic here.
            }

            if (input.Value is not null)
            {
                // TODO: Handle the game logic here.
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
        SudokuType SudokuType { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
