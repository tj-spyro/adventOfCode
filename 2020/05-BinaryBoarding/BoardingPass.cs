using System;

namespace BinaryBoarding
{
    public class BoardingPass
    {
        public int Row { get; }

        public int Column { get; }

        public int SeatId => (Row * 8) + Column;

        private BoardingPass(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public static BoardingPass CreateBoardingPass(string input)
        {
            var rowSegment = input
                .Substring(0, 7)
                .Replace('F', '0')
                .Replace('B', '1');

            var colSegment = input
                .Substring(7, 3)
                .Replace('L', '0')
                .Replace('R', '1');

            return new BoardingPass(Convert.ToInt32(rowSegment, 2), Convert.ToInt32(colSegment, 2));
        }
    }
}