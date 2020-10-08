using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Program_Test
    {
        [Fact]
        public void GivenBoardSizeOptionInput_ReturnABoardSizeMatchWithTheGivenSizeOption()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();

            var invalidBoardSizeOptionInput = "0";
            var validBoardSizeOptionInput = "2";

            testRead.SetToBeRead(invalidBoardSizeOptionInput);
            testRead.SetToBeRead(validBoardSizeOptionInput);


            var boardSizeOption = Program.RequestBoardSizeOption(testWrite.Write, testRead.Read);
            var actual = Program.SetBoardSize(boardSizeOption);

            Assert.True(testWrite.HasText("not a valid option"));
            Assert.Equal(4, actual);
        }
        
        [Fact]
        public void GivenInvalidNumberOfPlayerInput_ReturnInvalidMessage()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();

            var invalidNumberOfPlayersInput = "3";
            var validNumberOfPlayersInput = "2";

            testRead.SetToBeRead(invalidNumberOfPlayersInput);
            testRead.SetToBeRead(validNumberOfPlayersInput);

            var maxNumberOfPlayers = 2;
            
            Program.RequestNumberOfPlayers(maxNumberOfPlayers, testWrite.Write, testRead.Read);

            Assert.True(testWrite.HasText("not a valid number of players"));
        }

        public void GivenValidNumberOfPlayerInput_ReturnNumberOfPlayer()
        {
            var testRead = new TestRead();
            var testWrite = new TestWrite();

            var validNumberOfPlayersInput = "2";

            testRead.SetToBeRead(validNumberOfPlayersInput);

            var maxNumberOfPlayers = 2;
            
            var numberOfPlayers = Program.RequestNumberOfPlayers(maxNumberOfPlayers, testWrite.Write, testRead.Read);
            
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
          
            Program.PlayersChooseToken(numberOfPlayers, testWrite.Write, testRead.Read);

            Assert.True(testWrite.HasText("token is already taken"));
        }
    }
}
