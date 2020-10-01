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

            board.UpdateBoard(board, TokenType.X, "1,1");
            board.UpdateBoard(board, TokenType.X, "1,2");
            board.UpdateBoard(board, TokenType.X, "1,3");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.XWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheSameCol_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.X, "1,1");
            board.UpdateBoard(board, TokenType.X, "2,1");
            board.UpdateBoard(board, TokenType.X, "3,1");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.XWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheLeftDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.X, "1,1");
            board.UpdateBoard(board, TokenType.X, "2,2");
            board.UpdateBoard(board, TokenType.X, "3,3");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.XWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenXOnTheRightDiagonal_ReturnXWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.X, "1,3");
            board.UpdateBoard(board, TokenType.X, "2,2");
            board.UpdateBoard(board, TokenType.X, "3,1");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.XWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenOOnTheSameRow_ReturnOWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,1");
            board.UpdateBoard(board, TokenType.O, "1,2");
            board.UpdateBoard(board, TokenType.O, "1,3");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.OWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenOOnTheSameCol_ReturnOWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,1");
            board.UpdateBoard(board, TokenType.O, "2,1");
            board.UpdateBoard(board, TokenType.O, "3,1");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.OWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenOOnTheLeftDiagonal_ReturnOWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,1");
            board.UpdateBoard(board, TokenType.O, "2,2");
            board.UpdateBoard(board, TokenType.O, "3,3");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.OWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeTokenOOnTheRightDiagonal_ReturnOWin()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,3");
            board.UpdateBoard(board, TokenType.O, "2,2");
            board.UpdateBoard(board, TokenType.O, "3,1");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.OWin;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Fullboard_ReturnDraw()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,1");
            board.UpdateBoard(board, TokenType.O, "1,3");
            board.UpdateBoard(board, TokenType.O, "2,2");
            board.UpdateBoard(board, TokenType.O, "3,2");
            board.UpdateBoard(board, TokenType.X, "1,2");
            board.UpdateBoard(board, TokenType.X, "2,1");
            board.UpdateBoard(board, TokenType.X, "2,3");
            board.UpdateBoard(board, TokenType.X, "3,1");
            board.UpdateBoard(board, TokenType.X, "3,3");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.Draw;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotFullboardWithNoWinner_ReturnContinue()
        {
            var board = new Board();

            board.UpdateBoard(board, TokenType.O, "1,1");
            board.UpdateBoard(board, TokenType.O, "1,3");
            board.UpdateBoard(board, TokenType.O, "2,2");
            board.UpdateBoard(board, TokenType.O, "3,2");
            board.UpdateBoard(board, TokenType.X, "1,2");
            board.UpdateBoard(board, TokenType.X, "2,1");
            board.UpdateBoard(board, TokenType.X, "2,3");
            board.UpdateBoard(board, TokenType.X, "3,1");

            var actual = GameResult.CheckWinner(board);
            var expected = GameStatus.Continue;
            Assert.Equal(expected, actual);
        }
    }
}
