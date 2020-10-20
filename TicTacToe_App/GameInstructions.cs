using System;

namespace TicTacToe_App
{
    public static class GameInstructions
    {
        public static string PlayAgainQuestion()
        {
           return "Do you want to play again? Please enter y to play again or any other key to quit.";
        }

        public static string ChangeSettingsQuestion()
        {
           return  "Do you want to change the settings? Please enter y to change the settings or any other key to start play on current settings";
        }

        public static string GoodbyeMessage()
        {
           return  "Bye! See you next time!";
        }
        

        public static string InvalidInputMessage()
        {
            return "Sorry, it's not a valid option.";

        }

        public static string BoardTypeOption()
        {
            return "Please choose the board type with the option below: \n"
                + "1 for 2D Board \n"
                + "2 for 3D Board";
        }

        public static string BoardSizeOption(int boardTypeOption)
        {
            if(boardTypeOption == 1)
            {
                return "Please choose the board size with the option below: \n"
                + "1 for 3x3 board \n"
                + "2 for 4x4 board \n"
                + "3 for 5x5 board";
            }
            else
            {
                return "Please choose the board size with the option below: \n"
                + "1 for 3x3x3 board \n"
                + "2 for 4x4x4 board \n"
                + "3 for 5x5x5 board";
            }
            
        }

        public static string NumberOfPlayers(int boardTypeOption)
        {
            if(boardTypeOption == 1)
            {
                return "Please enter number of players to play with the rule below: \n"
                + "Minimum is 2 players \n"
                + "Maximum is 4 players \n"
                + "With 3x3 board, only 2 players can play";
            }
            else
            {
                return "Please enter number of players to play with the rule below: \n"
                + "Minimum is 2 players \n"
                + "Maximum is 4 players \n"
                + "With 3x3x3 board, only 2 players can play";   
            }
            
        }

        public static string PlayerChooseToken(int playerIndex)
        {
            return $"Player {playerIndex + 1} choose a token:";
        }

        public static string TakenTokenMessage()
        {
            return "Sorry, the token is already taken. Please choose another one!";
        }

        public static string WelcomeMessage(BoardType type)
        {
            if(type == BoardType.TwoD)
            {
                return "Welcome to 2D Tic Tac Toe!\nHere's the current board:\n";
            } 
            else
            {
                return "Welcome to 3D Tic Tac Toe!\nHere's the current board:\n";
            }
        }

        public static string EnterInputMessage(BoardType type, int playerIndex, string token)
        {
             if(type == BoardType.TwoD)
            {
                return $"Player {playerIndex + 1} enter a coord x,y to place your {token} or enter 'q' to give up:";
            } 
            else
            {
                return $"Player {playerIndex + 1} enter a coord x,y,z to place your {token} or enter 'q' to give up:";
            }
        }

        public static string InvalidCoordMessage()
        {
            return "Oh no, it's not a valid coord! Try again... \n";  
        }

        public static string OccupiedCellMessage()
        {
            return "Oh no, a piece is already at this place! Try again... \n";
        }

        public static string MoveAcceptedMessage()
        {
            return "Move accepted, here's the current board: \n";
        }

        public static string PlayerWinMessage(int playerIndex)
        {
            return $"Player {playerIndex + 1} win!";
        }

        public static string PlayerQuitMessage(int playerIndex)
        {
            return $"Player {playerIndex + 1} quit!";
        }

        public static string DrawGameMessage()
        {
            return "Draw!";
        }
    }
}
