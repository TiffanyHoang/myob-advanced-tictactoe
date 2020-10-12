using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class TestRead
    {
        private readonly Queue<string> _value = new Queue<string>();

        public void SetToBeRead(string value) => _value.Enqueue(value);

        public string Read() => _value.Dequeue();
    }

    public class TestWrite
    {
        private readonly Queue<string> _value = new Queue<string>();

        public void Write(string text) => _value.Enqueue(text);

        public string GetText() => _value.Dequeue();

        public bool HasText(string text)
        {
            var hasText = 0;
            foreach (var value in _value)
            {
                if (value.Contains(text))
                {
                    hasText += 1; 
                }
            }
            return hasText != 0;
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
            var playerList = new string[]{"T", "D"};

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("q");
            newGame.RunGame();

            Assert.Equal("Welcome to Tic Tac Toe!\nHere's the current board:\n", testWrite.GetText());

            Assert.Equal("...\n...\n...\n", testWrite.GetText());

        }

        [Fact]
        public void PlayerPressq_ReturnPlayerQuitStatus()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("q");

            Assert.Equal(GameStatus.PlayerQuit, newGame.RunGame());
        }

        [Fact]
        public void PlayerOWin_ReturnOWinStatus()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,2");
            testRead.SetToBeRead("2,1");
            testRead.SetToBeRead("2,2");
            testRead.SetToBeRead("3,3");
            testRead.SetToBeRead("3,2");

            newGame.RunGame();

            Assert.True(testWrite.HasText("Player 2 win"));
        }

        [Fact]
        public void PlayerEnterInvalidCoord_ReturnNotValidCoordMessage()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("-1,1");
            testRead.SetToBeRead("q");

            newGame.RunGame();
            Assert.True(testWrite.HasText("not a valid coord!"));
        }

        [Fact]
        public void PlayerEnterOccupiedCellCoord_ReturnOccupiedCellMessage()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};
            
            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("q");

            newGame.RunGame();
            Assert.True(testWrite.HasText("a piece is already at this place"));
        }

        [Fact]
        public void GivenTheFullBoard_ReturnDraw()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};
            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

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
