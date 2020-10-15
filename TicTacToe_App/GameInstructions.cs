using System;

namespace TicTacToe_App
{
    public static class GameInstructions
    {
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
