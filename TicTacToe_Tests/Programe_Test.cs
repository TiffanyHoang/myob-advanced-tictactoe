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
            testRead.SetToBeRead("0");
            testRead.SetToBeRead("4");
            testRead.SetToBeRead("2");


            var boardSizeOption = Program.RequestBoardSizeOption(testWrite.Write, testRead.Read);
            var actual = Program.SetBoardSize(boardSizeOption);
            Assert.True(testWrite.HasText("not a valid option"));
            Assert.Equal(4, actual);
        }

    }
}
