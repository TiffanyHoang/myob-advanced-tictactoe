using System;
using System.Linq;

namespace TicTacToe_App
{
    public class Rules
    {
        public static ValidationMessage CheckForValidCoord(Board board, string input)
        {
            try
            {
                var coordArray = input.Split(",").Select(int.Parse).ToArray();
                var not2IntegerNumbersSeparatedByComma = coordArray.Length != 2;

                if (not2IntegerNumbersSeparatedByComma)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var x = coordArray[0] - 1;
                var y = coordArray[1] - 1;
                var coordIsNegativeNumber = x < 0 || y < 0;

                var boardWidth = board.Grid.Length;
                var boardHeight = board.Grid[0].Length;
                var coordIsOutsideOfBoard = x >= boardWidth || y >= boardHeight;

                if (coordIsNegativeNumber || coordIsOutsideOfBoard)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var occupiedCoord = board.Grid[x][y] != " ";

                if (occupiedCoord)
                {
                    return ValidationMessage.OccupiedCell;
                }

                return ValidationMessage.ValidCoord;
            }
            catch
            {
                return ValidationMessage.InvalidCoord;
            }
        }

        public static ValidationInput CheckForValidBoardTypeOption(string input)
        {
            try {
                int boardTypeOption = int.Parse(input);
                return boardTypeOption < 1 || boardTypeOption > 2 ? ValidationInput.Invalid : ValidationInput.Valid;
            }
            catch 
            {
                return ValidationInput.Invalid;
            }
        }
    
        public static ValidationInput CheckForValidBoardSizeOption (string input)
        {
            try {
                int boardSizeOption = int.Parse(input);
                return boardSizeOption < 1 || boardSizeOption > 3 ? ValidationInput.Invalid : ValidationInput.Valid;
            }
            catch 
            {
                return ValidationInput.Invalid;
            }
        }

        public static ValidationInput CheckForValidNumberOfPlayersInput (int maxNumberOfPlayer, string input)
        {
            try {
                int numberOfPlayers = int.Parse(input);
                return numberOfPlayers > maxNumberOfPlayer || numberOfPlayers < 2 ? ValidationInput.Invalid : ValidationInput.Valid;
            }
            catch 
            {
                return ValidationInput.Invalid;
            }
        }
    
        public static ValidationInput CheckForValidTokenInput(string input)
        {
            if (input.Length > 1 || input == ".")
            {
                return ValidationInput.Invalid;
            } else {
                return ValidationInput.Valid;
            }
        }
    }
}
