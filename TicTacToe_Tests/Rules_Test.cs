using System;
using Xunit;
using TicTacToe_App;

namespace TicTacToe_Tests
{
    public class Rules_Test
    {
        [Theory]
        [InlineData("1", ValidationInput.Valid)]
        [InlineData("4", ValidationInput.Invalid)]
        [InlineData("0", ValidationInput.Invalid)]
        [InlineData("q", ValidationInput.Invalid)]
        public void GivenABoardSizeOption_ReturnCorrectResult(string boardSizeOption, ValidationInput expected)
        {
            var actual = Rules.CheckBoardSizeOption(boardSizeOption);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", ValidationInput.Valid)]
        [InlineData("3", ValidationInput.Invalid)]
        [InlineData("0", ValidationInput.Invalid)]
        [InlineData("q", ValidationInput.Invalid)]
        public void GivenABoardTypeOption_ReturnCorrectResult(string boardTypeOption, ValidationInput expected)
        {
            var actual = Rules.CheckBoardTypeOption(boardTypeOption);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "2", ValidationInput.Valid)]
        [InlineData(3, "4", ValidationInput.Invalid)]
        [InlineData(3, "1", ValidationInput.Invalid)]
        [InlineData(3, "q", ValidationInput.Invalid)]
        public void GivenNumberOfPlayers_ReturnCorrectResult(int maxNumberOfPLayer, string numberOfPlayersInput, ValidationInput expected)
        {
            var actual = Rules.CheckNumberOfPlayersInput(maxNumberOfPLayer, numberOfPlayersInput);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("x", ValidationInput.Valid)]
        [InlineData(".", ValidationInput.Invalid)]
        [InlineData("11", ValidationInput.Invalid)]
        public void GivenTokenInput_ReturnsCorrectResult(string tokenInput, ValidationInput expected)
        {
            var actual = Rules.CheckTokenInput(tokenInput);

            Assert.Equal(expected, actual);
        }
    }
}
