using System;

namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardSizeOption = RequestBoardSizeOption(Console.ReadLine, Console.WriteLine);
            var boardSize = SetBoardSize(boardSizeOption);
            var board = new Board(boardSize);

            var newGame = new TicTacToe(board, Console.Write, Console.ReadLine);
            newGame.RunGame();
        }

        public static int RequestBoardSizeOption(Func<string> read, Action<string> write)
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
    }
}
