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
    }
}
