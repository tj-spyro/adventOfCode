using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomCustoms.Forms
{
    public class DeclarationForm
    {
        private readonly IEnumerable<IndividualResponse> _responses;

        public DeclarationForm(string input)
        {
            _responses = input.Contains("\r\n")
                ? input.Split("\r\n",StringSplitOptions.RemoveEmptyEntries).Select(i => new IndividualResponse(i))
                : input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(i => new IndividualResponse(i));
        }

        public int PartySize => _responses.Count();

        public int DistinctYesAnswers => _responses.SelectMany(r => r.AnsweredYes).Distinct().Count();

        public int IntersectionOfAnswers => _responses.SelectMany(r => r.AnsweredYes).Distinct()
            .Count(w => _responses.All(t => t.AnsweredYes.Contains(w)));
    }
}