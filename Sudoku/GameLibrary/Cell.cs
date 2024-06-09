﻿namespace GameLibrary
{
    public class Cell : ICell
    {
        public int Value { get; set; }
        public int Field { get; private set; }
        public int[] Auxiliaries { get; set; }

        public Cell(int value, int field) {
            this.Value = value;
            this.Field = field;

            this.Auxiliaries = [];
        }

        public bool Validate(ISudoku sudoku, int HorizontalPosition, int VerticalPosition)
        {
            // TODO: Create a Validator for the cell.

            return false;
        }
    }

    public interface ICell
    {
        int Value { get; set; }
        int Field { get; }
        int[] Auxiliaries { get; set; }

        bool Validate(ISudoku sudoku, int HorizontalPosition, int VerticalPosition);
    }
}
