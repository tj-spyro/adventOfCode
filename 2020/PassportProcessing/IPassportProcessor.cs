namespace PassportProcessing
{
    public interface IPassportProcessor
    {
        int ValidPassports { get; }
        int ValidPassportWithFieldValidation { get; }
    }
}