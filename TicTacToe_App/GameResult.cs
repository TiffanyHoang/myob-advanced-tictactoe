using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe_App
{
    public class GameResult
    {
        public static GameStatus CheckWinner(Board board, string playerToken)
        {
            var winningCombinations =  GetWinningCombinations(board);

            var playerWin =  GetPlayerWinTokenArray(board, playerToken);

            var isPlayerWin = winningCombinations.Any(winningCombination => winningCombination.SequenceEqual(playerWin));
            
            var occupiedCells = GetOccupiedCells(board);
          
            var totalCellsOfBoard = board.BoardSize * board.BoardSize;

            if (isPlayerWin)
            {
                return GameStatus.Win;
            } else if(occupiedCells == totalCellsOfBoard)
            {
                return GameStatus.Draw;
            }

            return GameStatus.Continue;
        }
        private static int GetOccupiedCells(Board board)
        {
            var occupiedCells = 0; 
            foreach(var row in board.Grid)
            {
                foreach(var cell in row)
                {
                    if (cell != " ")
                    {
                        occupiedCells += 1;
                    }
                }
            }
            return occupiedCells;
        }
    
        private static List<string[]> GetWinningCombinations(Board board)
        {
            var winningCombinations = new List<string[]>();
            var winningCombinationDiagonals = new string[board.BoardSize];
            var winningCombinationAntiDiagonals = new string[board.BoardSize];
            int colIndexAntiDiagonal = board.BoardSize;

            for (int rowIndex = 0; rowIndex < board.BoardSize; rowIndex++)
            {
                var winningCombinationCols = new string[board.BoardSize];
                var winningCombinationRows = new string[board.BoardSize];
                for(int colIndex = 0; colIndex < board.BoardSize; colIndex++)
                {
                    winningCombinationCols[colIndex] = board.Grid[colIndex][rowIndex];
                    winningCombinationRows[colIndex] = board.Grid[rowIndex][colIndex];
                }
                winningCombinationDiagonals[rowIndex] = board.Grid[rowIndex][rowIndex];
                colIndexAntiDiagonal -= 1;
                winningCombinationAntiDiagonals[rowIndex] = board.Grid[rowIndex][colIndexAntiDiagonal];
                
                winningCombinations.Add(winningCombinationCols);
                winningCombinations.Add(winningCombinationRows);
                winningCombinations.Add(winningCombinationAntiDiagonals);
                winningCombinations.Add(winningCombinationDiagonals);
            }
            return winningCombinations;
        }

        private static string[] GetPlayerWinTokenArray(Board board, string playerToken)
        {
            var playerWin = new string[board.BoardSize];
            for( int i = 0; i< board.BoardSize; i++)
            {
                playerWin[i] = playerToken;
            }       

            return playerWin;
        }
    }
}
