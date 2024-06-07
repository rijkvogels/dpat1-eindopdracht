namespace DataTransfer.Factories
{
    internal class SudokuJigsawParser : ISudokuParser
    {
        public Sudoku Parse(string sudokuData)
        {
            var sudoku = new Sudoku
            {
                Grid = new Cell[9, 9]
            };

            var parts = sudokuData.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {

                var segments = part.Split('J');
                if (segments.Length != 2) continue;

                Console.WriteLine(segments[1]);

                int value = int.Parse(segments[0]);
                int field = int.Parse(segments[1]);

                int index = Array.IndexOf(parts, part);
                int row = index / 9;
                int col = index % 9;

                sudoku.Grid[row, col] = new Cell
                {
                    Value = value,
                    Field = field,
                    Auxiliaries = []
                };
            }

            return sudoku;
        }
    }
}
