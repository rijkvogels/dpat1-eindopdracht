namespace DataTransfer.Factories
{
    internal interface ISudokuParser
    {
        Sudoku Parse(string sudokuData);
    }
}
