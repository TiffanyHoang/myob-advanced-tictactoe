using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Program_Test
    {
        [Fact]
        public void GivenInvalidBoardSizeOptionInput_ReturnInvalidInputMessage()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var boardTypeOption = 1;
            var invalidBoardSizeOptionInput = "0";
            var validBoardSizeOptionInput = "2";

            testRead.SetToBeRead(invalidBoardSizeOptionInput);
            testRead.SetToBeRead(validBoardSizeOptionInput);

            var boardSizeOption = Program.GetBoardSizeOption(boardTypeOption,testWrite.Write, testRead.Read);

            Assert.True(testWrite.HasText(GameInstructions.InvalidInputMessage()));
        }

        [Fact]
        public void GivenBoardSizeOptionInput_ReturnABoardSizeMatchWithTheGivenSizeOption()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var boardSizeOption = 2;

            var actual = Program.SetBoardSize(boardSizeOption);

            Assert.Equal(4, actual);
        }
        
        [Fact]
        public void GivenInvalidNumberOfPlayerInput_ReturnInvalidMessage()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var boardTypeOption = 1;

            var invalidNumberOfPlayersInput = "3";
            var validNumberOfPlayersInput = "2";

            testRead.SetToBeRead(invalidNumberOfPlayersInput);
            testRead.SetToBeRead(validNumberOfPlayersInput);

            var maxNumberOfPlayers = 2;
            
            Program.GetNumberOfPlayers(boardTypeOption, maxNumberOfPlayers, testWrite.Write, testRead.Read);

            Assert.True(testWrite.HasText(GameInstructions.InvalidInputMessage()));
        }
        
        [Fact]
        public void GivenValidNumberOfPlayerInput_ReturnNumberOfPlayer()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var boardTypeOption = 1;

            var validNumberOfPlayersInput = "2";

            testRead.SetToBeRead(validNumberOfPlayersInput);

            var maxNumberOfPlayers = 2;
            
            var numberOfPlayers = Program.GetNumberOfPlayers(boardTypeOption, maxNumberOfPlayers, testWrite.Write, testRead.Read);
            
            var expected = int.Parse(validNumberOfPlayersInput);

            Assert.Equal(expected, numberOfPlayers);;
        }

        [Fact]
        public void GivenTwoSameTokenInputs_ReturnInvalidMessage()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var numberOfPlayers = 2;
            
            testRead.SetToBeRead("x");
            testRead.SetToBeRead("x");
            testRead.SetToBeRead("y");
          
            Program.GetPlayerList(numberOfPlayers, testWrite.Write, testRead.Read);

            Assert.True(testWrite.HasText(GameInstructions.TakenTokenMessage()));
        }

        [Fact]
        public void GivenTwoPlayerWithTokenTAndD_WhenPlayerPlacedTheirFirstToken_ReturnTheBoardWithTwoToken()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
            var board = new Board();
            var playerList = new string[]{"T", "D"};

            var newGame = new TicTacToe(board, playerList, testWrite.Write, testRead.Read);
            testRead.SetToBeRead("1,1");
            testRead.SetToBeRead("1,2");
            testRead.SetToBeRead("q");

            newGame.RunGame();

            Assert.True(testWrite.HasText("TD.\n...\n...\n"));
        }

        [Fact]
        public void GivenAnInvalidBoardTypeOption_ReturnTheInvalidInputMessage()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();

            var invalidBoardTypeOptionInput = "0";
            var validBoardTypeOptionInput = "2";

            testRead.SetToBeRead(invalidBoardTypeOptionInput);
            testRead.SetToBeRead(validBoardTypeOptionInput);

            var boardTypeOption = Program.GetBoardTypeOption(testWrite.Write, testRead.Read);
            
            Assert.True(testWrite.HasText(GameInstructions.InvalidInputMessage()));
        }

        [Theory]
        [InlineData(1, 3, BoardType.TwoD)]
        [InlineData(2, 3, BoardType.ThreeD)]
        public void GivenABoardTypeOption_ReturnCorrectBoard(int boardTypeOption, int boardSize, BoardType expectedBoardType)
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();

            var actualBoardType = Program.SetBoard(boardTypeOption,boardSize).Type;

            Assert.Equal(expectedBoardType, actualBoardType);
        }

        [Fact]
        public void Foo()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
        
            var gameResult = GameStatus.Win;
            
            var playerDecisionOnNextRound = "Y";
            var playerDecisionOnSettings = "Y";
            var boardTypeOption = "1";
            var boardSizeOption = "1";
            var numberOfPlayer = "2";
            var player1Token = "X";
            var player2Token = "O";

            testRead.SetToBeRead(playerDecisionOnNextRound);
            testRead.SetToBeRead(playerDecisionOnSettings);
            testRead.SetToBeRead(boardTypeOption);
            testRead.SetToBeRead(boardSizeOption);
            testRead.SetToBeRead(numberOfPlayer);
            testRead.SetToBeRead(player1Token);
            testRead.SetToBeRead(player2Token);
            testRead.SetToBeRead("q");

            Program.PlayRound(gameResult, testWrite.Write, testRead.Read);
            
            Assert.True(testWrite.HasText(GameInstructions.BoardTypeOption()));
        }

         [Fact]
        public void Foo2()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();
        
            var gameResult = GameStatus.Win;
            var boardType = BoardType.TwoD;

            var playerDecisionOnNextRound = "Y";
            var playerDecisionOnSettings = "N";

            testRead.SetToBeRead(playerDecisionOnNextRound);
            testRead.SetToBeRead(playerDecisionOnSettings);
         
            testRead.SetToBeRead("q");

            Program.PlayRound(gameResult, testWrite.Write, testRead.Read);
            
            Assert.True(testWrite.HasText(GameInstructions.WelcomeMessage(boardType)));
        }
        
    }
}
