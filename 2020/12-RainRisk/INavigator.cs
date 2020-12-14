using System.Drawing;
// ReSharper disable CheckNamespace

namespace RainRisk
{
    public interface INavigator
    {
        void ExecuteActions();
        void ExecuteAction(string input);
        Point CurrentPosition { get; }
        int GetManhattanDistance();
    }
}