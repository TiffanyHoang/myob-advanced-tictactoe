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
            return Array.FindAll(board.Cells, cell => cell != " ").Count();
        }

        private static string[] GetPlayerWinTokenArray(IBoard board, string playerToken)
        {  
            return (new string[board.Size]).Select(_ => playerToken).ToArray();
        }
    }
}
