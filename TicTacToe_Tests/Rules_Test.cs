using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Rules_Test
    {
        [Theory]
        [InlineData("1,1")]
        [InlineData("1,2")]
        [InlineData("1,3")]
        [InlineData("2,1")]
        [InlineData("2,2")]
        [InlineData("2,3")]
        [InlineData("3,1")]
        [InlineData("3,2")]
        [InlineData("3,3")]
        public void GivenAValidCoord_ReturnValidCoordMessage(string input)
        {
            var board = new Board();
            var inputCoord = input;

            var expected = ValidationMessage.ValidCoord;
            var actual = Rules.CheckForValidCoord(board, inputCoord);

            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("1-1")]
        [InlineData("a,b")]
        [InlineData("-1,1")]
        [InlineData("1,-1")]
        [InlineData("4,1")]
        [InlineData("1,4")]
        public void GivenAInvalidCoord_ReturnInvalidCoordMessage(string input)
        {
            var board = new Board();
            var inputCoord = input;

            var expected = ValidationMessage.InvalidCoord;
            var actual = Rules.CheckForValidCoord(board, inputCoord);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,1")]
        public void GivenAOccupiedCoord_ReturnOccupiedCellMessage(string input)
        {
            var board = new Board();
            board.UpdateBoard(board, TokenType.X, input);

            var expected = ValidationMessage.OccupiedCell;
            var actual = Rules.CheckForValidCoord(board, input);

            Assert.Equal(expected, actual);
        }
    }
}
