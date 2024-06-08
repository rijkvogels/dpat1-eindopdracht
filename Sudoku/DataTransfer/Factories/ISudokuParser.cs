using GameLibrary;

namespace DataTransfer.Factories
{
    internal interface ISudokuParser
    {
        ISudoku Parse(string sudokuData);
    }
}
