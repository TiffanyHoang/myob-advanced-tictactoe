using System;
using System.Linq;

namespace TicTacToe_App
{
    public class TicTacToe
    {
        private readonly Board _board;
        private readonly Action<string> _write;
        private readonly Func<string> _read;

        public TicTacToe(Board board, Action<string> write, Func<string> read)
        {
            _board = board;
            _write = write;
            _read = read;
        }

        public void RunGame()
        {

            _write("Welcome to Tic Tac Toe!\nHere's the current board:\n");

            PrintBoard();

            var player1 = "X";
            var player2 = "O";
            var currentPlayer = player1;

            _write($"{currentPlayer} enter a coord x,y to place your X or enter 'q' to give up:");

            var playerInput = _read();

        }

        private void PrintBoard()
        {
            var grid = _board.Grid;
           
            foreach (var row in grid)
            {
                foreach (var cell in row)
                {
                    _write(".");
                }
                _write("\n");
            }
        }

        public bool CheckForValidCoord(string input)
        {
            var coordArray = input.Split(",").Select(int.Parse).ToArray();
            var x = coordArray[0] - 1;
            var y = coordArray[1] - 1;
            var boardWidth = _board.Grid.Length;
            var boardHeight = _board.Grid[0].Length;

            var not2IntegerNumbersSeparatedByComma = coordArray.Length != 2 || double.IsNaN(x) || double.IsNaN(y);
            var coordIsNegativeNumber = x < 0 || y < 0;
            var coordIsOutsideOfBoard = x >= boardWidth || y>= boardHeight;
            var occupiedCell = _board.Grid[x][y] != TokenType.Empty;

            if (not2IntegerNumbersSeparatedByComma || coordIsNegativeNumber || coordIsOutsideOfBoard || occupiedCell)
            {
                return false;
            }

            return true;
        }


    }
}
