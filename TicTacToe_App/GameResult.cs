using System;
using System.Linq;

namespace TicTacToe_App
{
    public class GameResult
    {
        public static GameResults CheckWinner(Board board)
        {
            var winningCombinations = new TokenType[][] {
                new TokenType[] {board.Grid[0][0], board.Grid[0][1] , board.Grid[0][2] },
                new TokenType[] {board.Grid[1][0], board.Grid[1][1] , board.Grid[1][2] },
                new TokenType[] {board.Grid[2][0], board.Grid[2][1] , board.Grid[2][2] },
                new TokenType[] {board.Grid[0][0], board.Grid[1][0] , board.Grid[2][0] },
                new TokenType[] {board.Grid[0][1], board.Grid[1][1] , board.Grid[2][1] },
                new TokenType[] {board.Grid[0][2], board.Grid[1][2] , board.Grid[2][2] },
                new TokenType[] {board.Grid[0][0], board.Grid[1][1] , board.Grid[2][2] },
                new TokenType[] {board.Grid[0][2], board.Grid[1][1] , board.Grid[2][0] },
            };

            var xWin = new TokenType[] { TokenType.X, TokenType.X, TokenType.X };
            var oWin = new TokenType[] { TokenType.O, TokenType.O, TokenType.O };


            var isXWin = winningCombinations.Any(winningCombination => winningCombination.SequenceEqual(xWin));
            var isOWin = winningCombinations.Any(winningCombination => winningCombination.SequenceEqual(oWin));

            if (isXWin)
            {
                return GameResults.XWin;
            }

            if (isOWin)
            {
                return GameResults.OWin;
            }

            var emptyCells = 0; 
            foreach(var row in board.Grid)
            {
                foreach(var cell in row)
                {
                    if (cell !=TokenType.Empty)
                    {
                        emptyCells += 1;
                    }
                }
            }

            if (emptyCells == 9)
            {
                return GameResults.Draw;
            }

            return GameResults.Continue;
        }
    }
}
