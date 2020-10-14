using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class ThreeDBoard_Test
    {
        [Theory]
        [InlineData(3, 3*3*3)]
        public void WhenCreateABoard_ReturnEmptyCoordsMatchWithBoardSize(int boardSize, int expectedCells)
        {
            var board = new ThreeDBoard(boardSize);

            var cellCount = 0;

            foreach (var row in board.ThreeDGrid)
            {
                foreach (var col in row)
                {
                    foreach(var depth in col)
                    {
                        Assert.Equal(" ", depth);
                        cellCount += 1;
                    }
                }
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
        [InlineData("4,1,1", ValidationMessage.InvalidCoord)]
        [InlineData("2,2,2", ValidationMessage.OccupiedCell)]
        [InlineData("a,b,c", ValidationMessage.InvalidCoord)]
        public void GivenA3DCoord_ReturnCorrectResult(string input, ValidationMessage expected)
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("X", "2,2,2");
            var actual = board.CheckForValidCoord(input);

            Assert.Equal(expected, actual);
        }
        
    }
}
