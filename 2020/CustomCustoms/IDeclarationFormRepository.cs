using System.Collections.Generic;
using CustomCustoms.Forms;

namespace CustomCustoms
{
    public interface IDeclarationFormRepository
    {
        IEnumerable<DeclarationForm> Forms { get; }
        int SumOfYesAnswers { get; }
        int SumOfIntersectYesAnswers { get; }
    }
}