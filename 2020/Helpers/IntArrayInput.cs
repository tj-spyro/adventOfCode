using System.Linq;

namespace PuzzleInput
{
    public class IntArrayInput : InputDataBase<int[]>
    {
        public override int[] GetData(string path)
        {
            var rawInput = GetInput(path);

            return rawInput.Select(int.Parse).ToArray();
        }
    }
}