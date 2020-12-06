namespace CustomCustoms.Forms
{
    public class IndividualResponse
    {
        public readonly char[] AnsweredYes;

        public IndividualResponse(string input)
        {
            AnsweredYes = input.ToCharArray();
        }
    }
}