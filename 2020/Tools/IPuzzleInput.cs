using System.Collections.Generic;

namespace Tools
{
    public interface IPuzzleInput
    {
        string GetPuzzleInput(string url);

        string[] GetPuzzleInputAsArray(string url);

        IEnumerable<string> GetPuzzleInputSplitByBlankLines(string url);
    }
}