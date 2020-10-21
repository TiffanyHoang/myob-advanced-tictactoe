using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class TicTacToe_Test
    {
        [Fact]
        public void RunGame_PrintEmptyBoard()
        {
            var testWrite = new TestWrite();
            var testRead = new TestRead();
            var board = new Board();
            var playerList = new string[]{"T", "D"};
            var boardType = BoardType.TwoD;

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);

            testRead.SetToBeRead("q");
            newGame.RunGame();

            Assert.Equal(GameInstructions.WelcomeMessage(boardType), testWrite.GetText());

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

            Assert.True(testWrite.HasText(GameInstructions.PlayerWinMessage(Array.IndexOf(playerList,"D"))));
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
            Assert.True(testWrite.HasText(GameInstructions.InvalidCoordMessage()));
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
            Assert.True(testWrite.HasText(GameInstructions.OccupiedCellMessage()));
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
