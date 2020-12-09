namespace EncodingError
{
    public interface IXmasDecoder
    {
        long FindFirstInvalidNumber(int preamble = 25);
        long FindEncryptionWeakness(int preamble = 25);
        bool ValidNumber(int position, int preamble);
        (bool found, long min, long max) FindContiguousSet(long target, int startPosition);
    }
}