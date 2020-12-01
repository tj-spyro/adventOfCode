using System.Collections.Generic;
using System.IO;

namespace PuzzleInput
{
    public abstract class InputDataBase<T>
    {
        public abstract T GetData(string path);

        protected IEnumerable<string> GetInput(string path)
        {
            return File.ReadLines(path);
        }
    }
}
