using NUnit.Framework;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable StringLiteralTypo

namespace BinaryBoarding.Tests.BoardingPassUnitTests
{
    [TestFixture("FBFBBFFRLR", 44, 5, 357)]
    [TestFixture("BFFFBBFRRR", 70, 7, 567)]
    [TestFixture("FFFBBBFRRR", 14, 7, 119)]
    [TestFixture("BBFFBBFRLL", 102, 4, 820)]
    public class When_creating_from_string
    {
        private readonly string _input;
        private readonly int _row;
        private readonly int _column;
        private readonly int _seatId;

        private BoardingPass _boardingPass;

        public When_creating_from_string(string input, int row, int column, int seatId)
        {
            _input = input;
            _row = row;
            _column = column;
            _seatId = seatId;
        }

        [SetUp]
        public void Setup()
        {
            _boardingPass = BoardingPass.CreateBoardingPass(_input);
        }

        [Test]
        public void Then_the_row_is_correct()
        {
            Assert.That(_boardingPass.Row, Is.EqualTo(_row));
        }

        [Test]
        public void Then_the_column_is_correct()
        {
            Assert.That(_boardingPass.Column, Is.EqualTo(_column));
        }

        [Test]
        public void Then_the_seatId_is_correct()
        {
            Assert.That(_boardingPass.SeatId, Is.EqualTo(_seatId));
        }
    }
}