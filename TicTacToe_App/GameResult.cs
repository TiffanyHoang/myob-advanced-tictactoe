using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe_App
{
    public class GameResult
    {
        public static GameStatus CheckResult(IBoard board, string playerToken)
        {
            var resultCombinations = board.ResultCombinations;

            var playerTokenArray =  GetPlayerWinTokenArray(board, playerToken);

            var isPlayerWin = resultCombinations.Any(combination => combination.SequenceEqual(playerTokenArray));
            
            var totalOccupiedCells = GetTotalOccupiedCells(board);
          
            var totalCellsOfBoard = board.Cells.Count();
            
            if (isPlayerWin)
            {
                return GameStatus.Win;
            }
            else if(totalOccupiedCells == totalCellsOfBoard)
            {
                return GameStatus.Draw;
            }

            return GameStatus.Continue;
        }

        private static int GetTotalOccupiedCells(IBoard board)
        {
            var totalOccupiedCells = 0; 
            foreach(var cell in board.Cells)
            {
                if (cell != " ")
                {
                    totalOccupiedCells += 1;
                }
            }
            return totalOccupiedCells;
        }

        private static string[] GetPlayerWinTokenArray(IBoard board, string playerToken)
        {
            var playerWin = new string[board.Size];
            for( int i = 0; i< board.Size; i++)
            {
                playerWin[i] = playerToken;
            }       

            return playerWin;
        }
    }
}
