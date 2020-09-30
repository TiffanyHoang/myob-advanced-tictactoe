using System;
using System.Linq;

namespace TicTacToe_App
{
    public class Rules
    {
        public static bool CheckForValidCoord(Board board, string input)
        {

            try
            {
                var coordArray = input.Split(",").Select(int.Parse).ToArray();
                var not2IntegerNumbersSeparatedByComma = coordArray.Length != 2;

                if (not2IntegerNumbersSeparatedByComma)
                {
                    return false;
                }

                var x = coordArray[0] - 1;
                var y = coordArray[1] - 1;
                var coordIsNegativeNumber = x < 0 || y < 0;

                var boardWidth = board.Grid.Length;
                var boardHeight = board.Grid[0].Length;
                var coordIsOutsideOfBoard = x >= boardWidth || y >= boardHeight;

                if (coordIsNegativeNumber || coordIsOutsideOfBoard)
                {
                    return false;
                }

                var occupiedCoord = board.Grid[x][y] != TokenType.Empty;

                if (occupiedCoord)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
