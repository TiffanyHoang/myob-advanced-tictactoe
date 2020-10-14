using System;
using System.Linq;

namespace TicTacToe_App
{
    public class Rules
    {
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
