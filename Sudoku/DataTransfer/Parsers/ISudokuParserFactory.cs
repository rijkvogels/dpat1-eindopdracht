using GameLibrary;
using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    internal interface ISudokuParserFactory
    {
        ISudoku Parse(string sudokuData, SudokuType sudokuType);
    }
}
