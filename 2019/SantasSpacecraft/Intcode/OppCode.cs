namespace Intcode
{
    public enum OppCode
    {
        Add = 1,
        Multiply,
        Input,
        Output,
        JumpTrue,
        JumpFalse,
        LessThan,
        Equals,
        Terminate = 99
    }
}