using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class Board : IBoard
    {
        public BoardType Type 
        { 
            get {return BoardType.TwoD;}
        } 
        public string[][] Grid{ get; set; }
        public int Size{ get; set; }
        public Board(int size = 3)
        {
            Size = size;
            Grid = CreateGrid(Size);
        }

        private string[][] CreateGrid (int size)
        {
            var grid = new string[size][];
            for (int row = 0; row < size; row++)
            {
                var colArray = new string[size];
                for (int col = 0; col < size ; col++)
                {
                    colArray[col] = " ";
                }
                grid[row] = colArray;
            }
            return grid;

        }
        
        public string PrintBoard()
        {
            var boardString = "";

            foreach (var row in (string[][]) Convert.ChangeType(Grid, typeof(string[][])))
            {
                foreach (var cell in row)
                {
                    if (cell == " ")
                    {
                        boardString += ".";
                    } else
                    {
                        boardString += cell;
                    }
                }
                boardString += "\n";
            }
            return boardString;
        }

        public void UpdateBoard(string token, string coord)
        {
            var coordArray = coord.Split(",").Select(int.Parse).ToArray();
            var x = coordArray[0] - 1;
            var y = coordArray[1] - 1;
            Grid[x][y] = token;
        }

        public ValidationMessage CheckForValidCoord(string input)
        {
            try
            {
                var coordArray = input.Split(",").Select(int.Parse).ToArray();
                var not2IntegerNumbersSeparatedByComma = coordArray.Length != 2;

                if (not2IntegerNumbersSeparatedByComma)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var x = coordArray[0] - 1;
                var y = coordArray[1] - 1;
                var coordIsNegativeNumber = x < 0 || y < 0;

                var boardWidth = Grid.Length;
                var boardHeight = Grid[0].Length;
                var coordIsOutsideOfBoard = x >= boardWidth || y >= boardHeight;

                if (coordIsNegativeNumber || coordIsOutsideOfBoard)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var occupiedCoord = Grid[x][y] != " ";

                if (occupiedCoord)
                {
                    return ValidationMessage.OccupiedCell;
                }

                return ValidationMessage.ValidCoord;
            }
            catch
            {
                return ValidationMessage.InvalidCoord;
            }
        }

        public GameStatus CheckWinner(string playerToken)
        {
            var winningCombinations =  GetWinningCombinations();

            var playerWin =  GetPlayerWinTokenArray(playerToken);

            var isPlayerWin = winningCombinations.Any(winningCombination => winningCombination.SequenceEqual(playerWin));
            
            var occupiedCells = GetOccupiedCells();
          
            var totalCellsOfBoard = Size * Size;

            if (isPlayerWin)
            {
                return GameStatus.Win;
            } else if(occupiedCells == totalCellsOfBoard)
            {
                return GameStatus.Draw;
            }

            return GameStatus.Continue;
        }

        private int GetOccupiedCells()
        {
            var occupiedCells = 0; 
            foreach(var row in Grid)
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
    
        public List<string[]> GetWinningCombinations()
        {
            var winningCombinations = new List<string[]>();
            var winningCombinationDiagonals = new string[Size];
            var winningCombinationAntiDiagonals = new string[Size];
            int colIndexAntiDiagonal = Size;

            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                var winningCombinationCols = new string[Size];
                var winningCombinationRows = new string[Size];
                for(int colIndex = 0; colIndex < Size; colIndex++)
                {
                    winningCombinationCols[colIndex] = Grid[colIndex][rowIndex];
                    winningCombinationRows[colIndex] = Grid[rowIndex][colIndex];
                }
                winningCombinationDiagonals[rowIndex] = Grid[rowIndex][rowIndex];
                colIndexAntiDiagonal -= 1;
                winningCombinationAntiDiagonals[rowIndex] = Grid[rowIndex][colIndexAntiDiagonal];
                
                winningCombinations.Add(winningCombinationCols);
                winningCombinations.Add(winningCombinationRows);
                
            }

            winningCombinations.Add(winningCombinationAntiDiagonals);
            winningCombinations.Add(winningCombinationDiagonals);
            return winningCombinations;
        }

        private string[] GetPlayerWinTokenArray(string playerToken)
        {
            var playerWin = new string[Size];
            for( int i = 0; i< Size; i++)
            {
                playerWin[i] = playerToken;
            }       

            return playerWin;
        }

    }
}
