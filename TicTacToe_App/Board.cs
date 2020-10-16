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

            foreach (var row in Grid)
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
            var resultCombinations =  GetResultCombinations();

            var playerTokenArray =  GetPlayerTokenArray(playerToken);

            var isPlayerWin = resultCombinations.Any(combination => combination.SequenceEqual(playerTokenArray));
            
            var totalOccupiedCells = GetTotalOccupiedCells();
          
            var totalCellsOfBoard = Size * Size;

            if (isPlayerWin)
            {
                return GameStatus.Win;
            } else if(totalOccupiedCells == totalCellsOfBoard)
            {
                return GameStatus.Draw;
            }

            return GameStatus.Continue;
        }

        private int GetTotalOccupiedCells()
        {
            var totalOccupiedCells = Array.FindAll(Grid.SelectMany(row => row).ToArray(), cell => cell != " ").Count();; 
                        
            return totalOccupiedCells;
        }
    
        public List<string[]> GetResultCombinations()
        {
            var resultCombinations = new List<string[]>();
            var diagonals = new string[Size];
            var antiDiagonals = new string[Size];
            int colIndexAntiDiagonal = Size;

            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                var cols = new string[Size];
                var rows = new string[Size];
                for(int colIndex = 0; colIndex < Size; colIndex++)
                {
                    cols[colIndex] = Grid[colIndex][rowIndex];
                    rows[colIndex] = Grid[rowIndex][colIndex];
                }
                diagonals[rowIndex] = Grid[rowIndex][rowIndex];
                colIndexAntiDiagonal -= 1;
                antiDiagonals[rowIndex] = Grid[rowIndex][colIndexAntiDiagonal];
                
                resultCombinations.Add(cols);
                resultCombinations.Add(rows);
                
            }

            resultCombinations.Add(antiDiagonals);
            resultCombinations.Add(diagonals);
            return resultCombinations;
        }

        private string[] GetPlayerTokenArray(string playerToken)
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
