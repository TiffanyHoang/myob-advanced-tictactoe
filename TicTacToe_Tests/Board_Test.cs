using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Board_Test
    {
        [Theory]
        [InlineData(3, 3*3)]
        [InlineData(4, 4*4)]
        [InlineData(5, 5*5)]
        [InlineData(6, 6*6)]
        public void WhenCreateABoard_ReturnEmptyCoordsMatchWithBoardSize(int boardSize, int totalCells)
        {
            var board = new Board(boardSize);

            var cellCount = 0;

            foreach (var row in board.Grid)
            {
                foreach (var cell in row)
                {
                    Assert.Equal(" ", cell);
                    cellCount += 1;
                }
            }

            int expectedCells = totalCells;

            int actualCells = cellCount;

            Assert.Equal(expectedCells, actualCells);
        }

        [Fact]
        public void PrintBoard_WhenCreateABoard_ReturnEmptyBoard()
        {
            var board = new Board();
            var actual = board.PrintBoard();

            Assert.Equal("...\n...\n...\n", actual);
        }
    }
}
