namespace PassportProcessing.FieldValidators
{
    public interface IFieldValidator
    {
        bool IsValid(string value);
    }
}