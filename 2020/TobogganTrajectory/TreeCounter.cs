namespace TobogganTrajectory
{
    public class TreeCounter : ITreeCounter
    {
        private readonly Map _map;

        public TreeCounter(Map map)
        {
            _map = map;
        }

        public int Run(int right, int down)
        {
            var counter =0;

            while (_map.Move(right, down))
            {
                if (_map.IsTree())
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}