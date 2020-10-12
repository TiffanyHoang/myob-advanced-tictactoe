using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class GameResult_Test
    {
        [Fact]
        public void ThreeTokenXOnTheSameRow_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, "X", "1,1");
            board.UpdateBoard(board, "X", "1,2");
            board.UpdateBoard(board, "X", "1,3");

            var actual = GameResult.CheckWinner(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheSameCol_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, "X", "1,1");
            board.UpdateBoard(board, "X", "2,1");
            board.UpdateBoard(board, "X", "3,1");

            var actual = GameResult.CheckWinner(board, "X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, "X", "1,1");
            board.UpdateBoard(board, "X", "2,2");
            board.UpdateBoard(board, "X", "3,3");

            var actual = GameResult.CheckWinner(board,"X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheAntiDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, "X", "1,3");
            board.UpdateBoard(board, "X", "2,2");
            board.UpdateBoard(board, "X", "3,1");

            var actual = GameResult.CheckWinner(board,"X");
            var expected = GameStatus.Win;
            Assert.Equal(expected, actual);
        }

        

        [Fact]
        public void Fullboard_ReturnDraw()
        {
            var board = new Board();

            board.UpdateBoard(board, "O", "1,1");
            board.UpdateBoard(board, "O", "1,3");
            board.UpdateBoard(board, "O", "2,2");
            board.UpdateBoard(board, "O", "3,2");
            board.UpdateBoard(board, "X", "1,2");
            board.UpdateBoard(board, "X", "2,1");
            board.UpdateBoard(board, "X", "2,3");
            board.UpdateBoard(board, "X", "3,1");
            board.UpdateBoard(board, "X", "3,3");

            var actual = GameResult.CheckWinner(board, "X");
            var expected = GameStatus.Draw;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotFullboardWithNoWinner_ReturnContinue()
        {
            var board = new Board();

            board.UpdateBoard(board, "O", "1,1");
            board.UpdateBoard(board, "O", "1,3");
            board.UpdateBoard(board, "O", "2,2");
            board.UpdateBoard(board, "O", "3,2");
            board.UpdateBoard(board, "X", "1,2");
            board.UpdateBoard(board, "X", "2,1");
            board.UpdateBoard(board, "X", "2,3");
            board.UpdateBoard(board, "X", "3,1");

            var actual = GameResult.CheckWinner(board, "X");
            var expected = GameStatus.Continue;
            Assert.Equal(expected, actual);
        }
    }
}
