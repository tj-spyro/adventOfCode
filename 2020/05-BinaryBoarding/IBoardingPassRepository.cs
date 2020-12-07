namespace BinaryBoarding
{
    public interface IBoardingPassRepository
    {
        int MaxSeatId { get; }
        int FindSeat();
    }
}