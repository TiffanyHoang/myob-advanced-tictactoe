using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class ThreeDBoard_Test
    {
        [Theory]
        [InlineData(3, 3*3*3)]
        public void WhenCreateABoard_ReturnEmptyCoordsMatchWithBoardSize(int size, int expectedCells)
        {
            var board = new ThreeDBoard(size);

            var cellCount = 0;

            foreach(var cell in board.Cells)
            {
                Assert.Equal(" ", cell);
                cellCount += 1;
            }
             

            Assert.Equal(expectedCells, cellCount);
        }

        [Fact]
        public void PrintThreeDBoard_WhenCreateAThreeDBoard_ReturnEmptyBoard()
        {
            var board = new ThreeDBoard();
            var actual = board.PrintBoard();

            Assert.Equal("...\n...\n...\n\n...\n...\n...\n\n...\n...\n...\n\n", actual);
        }

        [Fact]
        public void PlaceAToken_ReturnUpdatedBoard()
        {
            var board = new ThreeDBoard();
            board.UpdateBoard("X", "1,1,1");
            var actual = board.PrintBoard();

            Assert.Equal("X..\n...\n...\n\n...\n...\n...\n\n...\n...\n...\n\n", actual);
        }

        [Theory]
        [InlineData("1,1,1", ValidationMessage.ValidCoord)]
        [InlineData("1,1", ValidationMessage.InvalidCoord)]
        [InlineData("-1,1,1", ValidationMessage.InvalidCoord)]
        [InlineData("4,1,1", ValidationMessage.InvalidCoord)]
        [InlineData("2,2,2", ValidationMessage.OccupiedCell)]
        [InlineData("a,b,c", ValidationMessage.InvalidCoord)]
        public void GivenA3DCoord_ReturnCorrectResult(string input, ValidationMessage expected)
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("X", "2,2,2");
            var actual = board.CheckCoord(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenAOccupiedCoord_ReturnOccupiedCellMessage()
        {
            var board = new ThreeDBoard();
            board.UpdateBoard("X", "1,1,1");

            var expected = ValidationMessage.OccupiedCell;
            var actual = board.CheckCoord("1,1,1");

            Assert.Equal(expected, actual);
        }

    }
}
