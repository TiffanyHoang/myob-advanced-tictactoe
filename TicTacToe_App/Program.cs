using System;

namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardSizeOption = RequestBoardSizeOption();
            var boardSize = SetBoardSize(boardSizeOption);
            var board = new Board(boardSize);

            var newGame = new TicTacToe(board, Console.Write, Console.ReadLine);
            newGame.RunGame();
        }

        public static int RequestBoardSizeOption()
        {
            var boardSizeInput = "";
            while (true)
            {
                Console.WriteLine("Please choose the board size with the option below: \n"
                +   "1 for 3x3 board \n"
                +   "2 for 4x4 board \n"
                +   "3 for 5x5 board");
            
                boardSizeInput = Console.ReadLine();

                var validationInput = Rules.CheckForValidBoardSizeOption(boardSizeInput);

                if (validationInput == ValidationInput.Valid)
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
