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
        public void GivenACoord_ReturnCorrectResult(string input)
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
            board.UpdateBoard(board, "X", input);

            var expected = ValidationMessage.OccupiedCell;
            var actual = Rules.CheckForValidCoord(board, input);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("1", ValidationInput.Valid)]
        [InlineData("4", ValidationInput.Invalid)]
        [InlineData("0", ValidationInput.Invalid)]
        [InlineData("q", ValidationInput.Invalid)]
        public void GivenABoardSizeOption_ReturnCorrectResult(string boardSizeOption, ValidationInput expected)
        {
            var actual = Rules.CheckForValidBoardSizeOption(boardSizeOption);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "2", ValidationInput.Valid)]
        [InlineData(3, "4", ValidationInput.Invalid)]
        [InlineData(3, "1", ValidationInput.Invalid)]
        [InlineData(3, "q", ValidationInput.Invalid)]
        public void GivenNumberOfPlayers_ReturnCorrectResult(int maxNumberOfPLayer, string numberOfPlayersInput, ValidationInput expected)
        {
            var actual = Rules.CheckForValidNumberOfPlayersInput(maxNumberOfPLayer, numberOfPlayersInput);

            Assert.Equal(expected, actual);
        }

         [Theory]
        [InlineData("x", ValidationInput.Valid)]
        [InlineData(".", ValidationInput.Invalid)]
        [InlineData("11", ValidationInput.Invalid)]
        public void GivenTokenInput_ReturnsCorrectResult(string tokenInput, ValidationInput expected)
        {
            var actual = Rules.CheckForValidTokenInput(tokenInput);

            Assert.Equal(expected, actual);
        }
    }
}
