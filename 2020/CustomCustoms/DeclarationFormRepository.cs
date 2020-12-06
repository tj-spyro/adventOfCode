using System.Collections.Generic;
using System.Linq;
using CustomCustoms.Forms;
using Tools;

namespace CustomCustoms
{
    public class DeclarationFormRepository : IDeclarationFormRepository
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string PuzzleInputUrl = "https://adventofcode.com/2020/day/6/input";

        private IEnumerable<string> _rawData;
        private IEnumerable<string> RawData => _rawData ??= _puzzleInput.GetPuzzleInputSplitByBlankLines(PuzzleInputUrl);

        public DeclarationFormRepository(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        private IEnumerable<DeclarationForm> _forms;
        public IEnumerable<DeclarationForm> Forms => _forms ??= RawData.Select(d => new DeclarationForm(d));

        public int SumOfYesAnswers => Forms.Sum(f => f.DistinctYesAnswers);
        public int SumOfIntersectYesAnswers => Forms.Sum(f => f.IntersectionOfAnswers);
    }
}