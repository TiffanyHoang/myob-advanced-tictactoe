using System;
using System.Linq;

namespace TicTacToe_App
{
    public class Rules
    {
        public static ValidationInput CheckBoardTypeOption(string input)
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
    
        public static ValidationInput CheckBoardSizeOption (string input)
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

        public static ValidationInput CheckNumberOfPlayersInput (int maxNumberOfPlayer, string input)
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
    
        public static ValidationInput CheckTokenInput(string input)
        {
            return input.Length > 1 || input == "." ? ValidationInput.Invalid : ValidationInput.Valid;
        }
    }
}
