using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class GameResult_Test
    {
        [Fact]
        public void ThreeTokenXOnTheSameRow_2DBoard_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "1,2");
            board.UpdateBoard("X", "1,3");

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheSameCol_2DBoard_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "2,1");
            board.UpdateBoard("X", "3,1");

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheDiagonal_2DBoard_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,1");
            board.UpdateBoard("X", "2,2");
            board.UpdateBoard("X", "3,3");

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheAntiDiagonal_2DBoard_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard("X", "1,3");
            board.UpdateBoard("X", "2,2");
            board.UpdateBoard("X", "3,1");

            var actual = GameResult.CheckResult(board, "X");
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

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Draw;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotFullboardWithNoWinner_2DBoard_ReturnContinue()
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

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Continue;
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
        public void GivenSameThreeTokenOnTheSameLine_3DBoard_ReturnWin(string combinationName, string coord1, string coord2, string coord3)
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("X", coord1);
            board.UpdateBoard("X", coord2);
            board.UpdateBoard("X", coord3);

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1stCornerDiagonal", "1,1,1", "2,2,2", "3,3,3", "4,4,4")]
        [InlineData("2ndCornerDiagonal", "1,1,4", "2,2,3", "3,3,2", "4,4,1")]
        [InlineData("3rdCornerDiagonal", "1,4,1", "2,3,2", "3,2,3", "4,1,4")]
        [InlineData("4thCornerDiagonal", "1,4,4", "2,3,3", "3,2,2", "4,1,1")]
        public void GivenSameThreeTokenOnTheSameLineBoardSize4_3DBoard_ReturnWin(string combinationName, string coord1, string coord2, string coord3, string coord4)
        {
            var board = new ThreeDBoard(4);

            board.UpdateBoard("X", coord1);
            board.UpdateBoard("X", coord2);
            board.UpdateBoard("X", coord3);
            board.UpdateBoard("X", coord4);

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Fullboard_3DBoard_ReturnDraw()
        {
            var board = new ThreeDBoard();

            board.UpdateBoard("A", "1,1,1");
            board.UpdateBoard("O", "1,1,2");
            board.UpdateBoard("X", "1,1,3");
            board.UpdateBoard("B", "1,2,1");
            board.UpdateBoard("X", "1,2,2");
            board.UpdateBoard("O", "1,2,3");
            board.UpdateBoard("A", "1,3,1");
            board.UpdateBoard("B", "1,3,2");
            board.UpdateBoard("O", "1,3,3");
            board.UpdateBoard("A", "2,1,1");
            board.UpdateBoard("X", "2,1,2");
            board.UpdateBoard("B", "2,1,3");
            board.UpdateBoard("X", "2,2,1");
            board.UpdateBoard("O", "2,2,2");
            board.UpdateBoard("A", "2,2,3");
            board.UpdateBoard("B", "2,3,1");
            board.UpdateBoard("X", "2,3,2");
            board.UpdateBoard("O", "2,3,3");
            board.UpdateBoard("B", "3,1,1");           
            board.UpdateBoard("A", "3,1,2");
            board.UpdateBoard("X", "3,1,3");
            board.UpdateBoard("O", "3,2,1");
            board.UpdateBoard("A", "3,2,2");
            board.UpdateBoard("B", "3,2,3");
            board.UpdateBoard("O", "3,3,1");
            board.UpdateBoard("X", "3,3,2");
            board.UpdateBoard("A", "3,3,3");

            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Draw;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotFullboardWithNoWinner_3DBoard_ReturnContinue()
        {
            var board = new ThreeDBoard();
            board.UpdateBoard("X", "2,2,1");
            board.UpdateBoard("O", "1,1,1");
            board.UpdateBoard("X", "2,2,2");
            board.UpdateBoard("O", "1,1,2");
           
            var actual = GameResult.CheckResult(board, "X");
            var expected = GameStatus.Continue;
            Assert.Equal(expected, actual);
        }
    }
}
