namespace PassportProcessing.FieldValidators
{
    public class YearFieldValidator : IFieldValidator
    {
        private readonly int _earliestYear;
        private readonly int _latestYear;

        public YearFieldValidator(int earliestYear, int latestYear)
        {
            _earliestYear = earliestYear;
            _latestYear = latestYear;
        }

        public bool IsValid(string value)
        {
            return int.TryParse(value, out _)
                   && int.Parse(value) >= _earliestYear
                   && int.Parse(value) <= _latestYear;
        }
    }
}