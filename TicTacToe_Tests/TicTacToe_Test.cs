using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class TestRead
    {
        private Queue<string> _value = new Queue<string>();

        public void SetToBeRead(string value)
        {
            _value.Enqueue(value);
        }

        public string Read()
        {
            return _value.Dequeue();
        }
    }

    public class TestWrite
    {
        private Queue<string> _value = new Queue<string>();

        public void Write(string text)
        {
            _value.Enqueue(text);
        }

        public string GetText()
        {
            return _value.Dequeue();
        }

        public bool HasText(string text)
        {
            return _value.Contains(text);
        }
    }

    public class TicTacToe_Test
    {
        [Fact]
        public void RunGame_PrintEmptyBoard()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("q");
            newGame.RunGame();

            Assert.Equal("Welcome to Tic Tac Toe!\nHere's the current board:\n", testWrite.GetText());

            Assert.Equal("...\n...\n...\n", testWrite.GetText());

        }

        [Fact]
        public void PlayerPressq_ReturnIndicator()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("q");

            Assert.Equal(GameStatus.PlayerQuit, newGame.RunGame());
        }

        [Fact]
        public void PlayerXWin_ReturnXWinStatus()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,2");
            testRead.SetToBeRead("2,1");
            testRead.SetToBeRead("1,3");
            testRead.SetToBeRead("3,1");

            Assert.Equal(GameStatus.XWin, newGame.RunGame());
        }

        [Fact]
        public void PlayerOWin_ReturnOWinStatus()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,2");
            testRead.SetToBeRead("2,1");
            testRead.SetToBeRead("2,2");
            testRead.SetToBeRead("3,3");
            testRead.SetToBeRead("3,2");

            Assert.Equal(GameStatus.OWin, newGame.RunGame());
        }

        [Fact]
        public void PlayerEnterInvalidCoord_ReturnErrorMessage()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("-1,1");
            testRead.SetToBeRead("q");

            newGame.RunGame();
            Assert.True(testWrite.HasText("Opps, it's not a valid coord! Try again... \n"));
        }

        [Fact]
        public void GivenTheFullBoard_ReturnDraw()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var newGame = new TicTacToe(board, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,2");
            testRead.SetToBeRead("2,1");
            testRead.SetToBeRead("2,2");
            testRead.SetToBeRead("3,3");
            testRead.SetToBeRead("3,1");
            testRead.SetToBeRead("3,2");
            testRead.SetToBeRead("2,3");
            testRead.SetToBeRead("1,3");

            Assert.Equal(GameStatus.Draw, newGame.RunGame());
        }
    }
}
