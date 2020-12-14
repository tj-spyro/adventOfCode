namespace ShuttleSearch
{
    public interface ITimeTable
    {
        int NextDeparture();
        int WaitTime();
        int Solve1();
        int Solve2();
    }
}