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

        public string[] Cells 
        {
            get { return GetCells();}
        }

        public int Size { get; set; }

        public List<string[]> ResultCombinations 
        {
            get { return GetResultCombinations();}
        }

        private string[][] Grid{ get; set; }

        public Board(int size = 3)
        {
            Size = size;
            Grid = CreateGrid();
        }

        public string PrintBoard()
        {
            var boardString = "";

            foreach (var row in Grid)
            {
                foreach (var cell in row)
                {
                    var stringToAppend = cell == " " ? "." : cell;
                    boardString += stringToAppend;
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

        public ValidationMessage CheckCoord(string input)
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
        
        private string[][] CreateGrid ()
        {
            var grid = (new string[Size][])
                    .Select(_ => {
                        return (new string[Size]).Select(_ => " ").ToArray();
                    }).ToArray();
            
            return grid;
        }
        
        private string[] GetCells()
        {
            var cells = Grid.SelectMany(row => row).ToArray();             

            return cells;
        }
    

    }
}
