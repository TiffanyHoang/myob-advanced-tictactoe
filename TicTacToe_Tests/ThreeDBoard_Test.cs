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
        [InlineData("2,2,2", ValidationMessage.OccupiedCell)]
        [InlineData("a,b,c", ValidationMessage.InvalidCoord)]
        public void GivenA3DCoord_ReturnCorrectResult(string input, ValidationMessage expected)
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("X", "2,2,2");
            var actual = board.CheckForValidCoord(input);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("ZEdge", "1,1,1", "1,1,2", "1,1,3")]
        [InlineData("YEdge", "1,1,1", "1,2,1", "1,3,1")]
        [InlineData("XEdge", "1,1,1", "2,1,1", "3,1,1")]
        [InlineData("XDiagonal", "1,1,1", "1,2,2", "1,3,3")]
        [InlineData("XAntiDiagonal", "1,1,3", "1,2,2", "1,3,1")]
        [InlineData("YDiagonal", "1,1,1", "2,2,1", "3,3,1")]
        [InlineData("YAntiDiagonal", "1,3,1", "2,2,1", "3,1,1")]
        [InlineData("ZDiagonal", "1,3,1", "2,3,2", "3,3,3")]
        [InlineData("ZAntiDiagonal", "1,1,3", "2,1,2", "3,1,1")]
        [InlineData("1stCornerDiagonal", "1,1,1", "2,2,2", "3,3,3")]
        [InlineData("2ndCornerDiagonal", "1,1,3", "2,2,2", "3,3,1")]
        [InlineData("3rdCornerDiagonal", "1,3,1", "2,2,2", "3,1,3")]
        [InlineData("4thCornerDiagonal", "1,3,3", "2,2,2", "3,1,1")]
        public void GivenSameThreeTokenOnTheSameLine_ReturnWin(string combinationName, string coord1, string coord2, string coord3)
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("X", coord1);
            board.UpdateBoard("X", coord2);
            board.UpdateBoard("X", coord3);

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1stCornerDiagonal", "1,1,1", "2,2,2", "3,3,3", "4,4,4")]
        [InlineData("2ndCornerDiagonal", "1,1,4", "2,2,3", "3,3,2", "4,4,1")]
        [InlineData("3rdCornerDiagonal", "1,4,1", "2,3,2", "3,2,3", "4,1,4")]
        [InlineData("4thCornerDiagonal", "1,4,4", "2,3,3", "3,2,2", "4,1,1")]
        public void GivenSameThreeTokenOnTheSameLineBoardSize4_ReturnWin(string combinationName, string coord1, string coord2, string coord3, string coord4)
        {
            var board = new ThreeDBoard(4);

            board.UpdateBoard("X", coord1);
            board.UpdateBoard("X", coord2);
            board.UpdateBoard("X", coord3);
            board.UpdateBoard("X", coord4);

            var actual = board.CheckWinner("X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }
    }
}
