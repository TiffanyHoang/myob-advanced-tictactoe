using System;

namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardSizeOption = RequestBoardSizeOption( Console.WriteLine, Console.ReadLine);
            var boardSize = SetBoardSize(boardSizeOption);
            var board = new Board(boardSize);

            RequestNumberOfPlayers(board, Console.WriteLine, Console.ReadLine);

            var newGame = new TicTacToe(board, Console.Write, Console.ReadLine);
            newGame.RunGame();
        }

        public static int RequestBoardSizeOption(Action<string> write,Func<string> read)
        {
            var boardSizeInput = "";
            while (true)
            {
                write("Please choose the board size with the option below: \n"
                +   "1 for 3x3 board \n"
                +   "2 for 4x4 board \n"
                +   "3 for 5x5 board");
            
                boardSizeInput = read();

                var validationInput = Rules.CheckForValidBoardSizeOption(boardSizeInput);
                if (validationInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid option.");
                } else
                {
                    break;
                }
            }
            return int.Parse(boardSizeInput);
        }

        public static int SetBoardSize(int boardSizeOption)
        {
            var boardSize = 0;
            if(boardSizeOption == 1)
            {
                boardSize = 3;
            } else if (boardSizeOption == 2)
            {
                boardSize = 4;
            } else {
                boardSize = 5;
            }
            return boardSize;
        }

        public static int RequestNumberOfPlayers(Board board, Action<string> write,  Func<string> read)
        {
            var numberOfPlayersInput = "";
            while (true)
            {
                write("Please enter number of players to play with the rule below: \n"
                +   "Minimum is 2 players \n"
                +   "Maxunyn us 4 players \n"
                +   "With 3x3 board, only 2 players can play");
            
                numberOfPlayersInput = read();

                var validationInput = Rules.CheckForValidNumberOfPlayersInput(board, numberOfPlayersInput);

                if (validationInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid number of players.");
                } else
                {
                    break;
                }
            }
            return int.Parse(numberOfPlayersInput);
        }
    }
}
