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

        [Theory]
        [InlineData("4")]
        [InlineData("0")]
        [InlineData("-1")]   
        [InlineData("q")]
        public void GivenAnInvalidaBoardSizeOption_ReturnInvalidBoardSizeOptionMessage(string boardSizeOption)
        {
            var expected = ValidationInput.Invalid;
            var actual = Rules.CheckForValidBoardSizeOption(boardSizeOption);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void GivenAValidaBoardSizeOption_ReturnValidBoardSizeOptionMessage(string boardSizeOption)
        {
            var expected = ValidationInput.Valid;
            var actual = Rules.CheckForValidBoardSizeOption(boardSizeOption);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "2")]
        [InlineData(4, "2")]
        [InlineData(5, "2")]
        [InlineData(4, "3")]
        [InlineData(5, "3")]
        [InlineData(4, "4")]
        [InlineData(5, "4")]
        public void GivenValidNumberOfPlayers_ReturnValidInput(int boardSize, string numberOfPlayersInput)
        {
            var board = new Board(boardSize);
            var expected = ValidationInput.Valid;
            var actual = Rules.CheckForValidNumberOfPlayersInput(board, numberOfPlayersInput);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, "3")]
        [InlineData(3, "4")]
        [InlineData(3, "q")]
        [InlineData(3, "1")]
        [InlineData(3, "5")]
        [InlineData(3, "-1")]
        public void GivenInvalidNumberOfPlayers_ReturnInvalidInput(int boardSize, string numberOfPlayersInput)
        {
            var board = new Board(boardSize);
            var expected = ValidationInput.Invalid;
            var actual = Rules.CheckForValidNumberOfPlayersInput(board, numberOfPlayersInput);

            Assert.Equal(expected, actual);
        }
    }
}
