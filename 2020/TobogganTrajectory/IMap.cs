namespace TobogganTrajectory
{
    public interface IMap
    {
        bool IsTree();
        bool Move(int right, int down);
        void Reset();
    }
}