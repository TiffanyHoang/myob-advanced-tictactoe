using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Board_Test
    {
        [Fact]
        public void WhenCreateABoard_ReturnA9EmptyCells()
        {
            var board = new Board();

            var grid = board.Grid;

            var cellCount = 0;

            foreach (var row in grid)
            {
                foreach (var cell in row)
                {
                    Assert.Equal(TokenType.Empty, cell);
                    cellCount += 1;
                }
            }

            int expectedCells = 9;

            int actualCells = cellCount;

            Assert.Equal(expectedCells, actualCells);
        }
    }
}
