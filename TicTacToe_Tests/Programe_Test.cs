using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Program_Test
    {
         [Fact]
        public void GivenBoardSizeInput_ReturnABoardMatchWithTheGivenSize()
        {
            var testRead = new TestRead();
            var boardSizeOption = Program.RequestBoardSizeOption();
            var actual = Program.SetBoardSize(boardSizeOption);
            testRead.SetToBeRead("2");

            Assert.Equal(4, actual);
        }

    }
}
