using GameLibrary;
using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    public interface ISudokuParserFactory
    {
        ISudoku Parse(string sudokuData, SudokuType sudokuType);
    }
}
