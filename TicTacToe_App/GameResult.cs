﻿using System;
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
            
            var emptyCells = 0; 
            foreach(var row in board.Grid)
            {
                foreach(var cell in row)
                {
                    if (cell != " ")
                    {
                        emptyCells += 1;
                    }
                }
            }

            var cellCount = 0;
            foreach (var row in board.Grid)
            {
                foreach (var cell in row)
                {
                    cellCount += 1;
                }
            }

            if (isPlayerWin)
            {
                return GameStatus.Win;
            } else if(emptyCells == cellCount)
            {
                return GameStatus.Draw;
            }

            return GameStatus.Continue;
        }

        private static List<string[]> GetWinningCombinations(Board board)
        {
            var winningCombinations = new List<string[]>();

            for (int rowIndex = 0; rowIndex < board.BoardSize; rowIndex++)
            {
                var winningCombinationRows = new string[board.BoardSize];
                for(int colIndex = 0; colIndex < board.BoardSize; colIndex++)
                {
                    winningCombinationRows[colIndex] = board.Grid[rowIndex][colIndex];
                }
                winningCombinations.Add(winningCombinationRows) ;
            }

            for (int rowIndex = 0; rowIndex < board.BoardSize; rowIndex++)
            {
                var winningCombinationCols = new string[board.BoardSize];
                for(int colIndex = 0; colIndex < board.BoardSize; colIndex++)
                {
                    winningCombinationCols[colIndex] = board.Grid[colIndex][rowIndex];
                }
                winningCombinations.Add(winningCombinationCols);
            }
            
            var winningCombinationDiagonals = new string[board.BoardSize];
            for (int rowIndex = 0; rowIndex < board.BoardSize; rowIndex++)
            {
                var colIndex = rowIndex;
                winningCombinationDiagonals[rowIndex] = board.Grid[rowIndex][colIndex];
            }
             winningCombinations.Add(winningCombinationDiagonals);

            var winningCombinationAntiDiagonals = new string[board.BoardSize];
            int colIndexAntiDiagonal = board.BoardSize;
            for (int rowIndex = 0; rowIndex < board.BoardSize; rowIndex++)
            {
                colIndexAntiDiagonal -= 1;
                winningCombinationAntiDiagonals[rowIndex] = board.Grid[rowIndex][colIndexAntiDiagonal];
            }
            winningCombinations.Add(winningCombinationAntiDiagonals);

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
