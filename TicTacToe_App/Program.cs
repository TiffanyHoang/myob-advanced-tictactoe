using System;

namespace TicTacToe_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var newGame = new TicTacToe(board, Console.Write, Console.ReadLine);
            newGame.RunGame();
        }
    }
}
