using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public ISudoku Sudoku { get; }
        
        public SudokuType SudokuType { get; }
        public ViewType ViewType { get; private set;  }

        public Game(ISudoku sudoku, SudokuType sudokuType) {
            this.Sudoku = sudoku;
            this.SudokuType = sudokuType;

            this.ViewType = ViewType.Definite;
        }

        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }

            // TODO: Handle the game logic here.

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
        ViewType ViewType { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
