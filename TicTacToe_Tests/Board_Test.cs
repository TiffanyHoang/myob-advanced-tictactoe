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

        [Fact]
        public void PlaceAToken_ReturnUpdatedBoard()
        {
            var board = new Board();
            board.UpdateBoard("X", "1,1");
            var actual = board.PrintBoard();

            Assert.Equal("X..\n...\n...\n", actual);
        }

        [Fact]
        public void ThreeTokenXOnTheSameRow_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "1,2");
            board.UpdateBoard("X", "1,3");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheSameCol_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "2,1");
            board.UpdateBoard("X", "3,1");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "2,2");
            board.UpdateBoard("X", "3,3");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheAntiDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,3");
            board.UpdateBoard("X", "2,2");
            board.UpdateBoard("X", "3,1");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        

        [Fact]
        public void Fullboard_ReturnDraw()
        {
            var board = new Board();

            board.UpdateBoard("O", "1,1");
            board.UpdateBoard("O", "1,3");
            board.UpdateBoard("O", "2,2");
            board.UpdateBoard("O", "3,2");
            board.UpdateBoard("X", "1,2");
            board.UpdateBoard("X", "2,1");
            board.UpdateBoard("X", "2,3");
            board.UpdateBoard("X", "3,1");
            board.UpdateBoard("X", "3,3");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Draw;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotFullboardWithNoWinner_ReturnContinue()
        {
            var board = new Board();

            board.UpdateBoard("O", "1,1");
            board.UpdateBoard("O", "1,3");
            board.UpdateBoard("O", "2,2");
            board.UpdateBoard("O", "3,2");
            board.UpdateBoard("X", "1,2");
            board.UpdateBoard("X", "2,1");
            board.UpdateBoard("X", "2,3");
            board.UpdateBoard("X", "3,1");

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Continue;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,1")]
        [InlineData("1,2")]
        [InlineData("1,3")]
        [InlineData("2,1")]
        [InlineData("2,2")]
        [InlineData("2,3")]
        [InlineData("3,1")]
        [InlineData("3,2")]
        [InlineData("3,3")]
        public void GivenAValidCoord_ReturnValidCoordMessage(string input)
        {
            var board = new Board();
            var inputCoord = input;

            var expected = ValidationMessage.ValidCoord;
            var actual = board.CheckForValidCoord(inputCoord);

            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("1-1")]
        [InlineData("a,b")]
        [InlineData("-1,1")]
        [InlineData("1,-1")]
        [InlineData("4,1")]
        [InlineData("1,4")]
        public void GivenACoord_ReturnCorrectResult(string input)
        {
            var board = new Board();
            var inputCoord = input;

            var expected = ValidationMessage.InvalidCoord;
            var actual = board.CheckForValidCoord(inputCoord);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,1")]
        public void GivenAOccupiedCoord_ReturnOccupiedCellMessage(string input)
        {
            var board = new Board();
            board.UpdateBoard("X", input);

            var expected = ValidationMessage.OccupiedCell;
            var actual = board.CheckForValidCoord(input);

            Assert.Equal(expected, actual);
        }

    }
}
