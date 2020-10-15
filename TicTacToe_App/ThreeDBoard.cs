using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class ThreeDBoard : IBoard
    {
        public BoardType Type 
        { 
            get { return BoardType.ThreeD; }
        } 
        public string[][][] ThreeDGrid{ get; set; }
        public int Size{ get; set; }
        public ThreeDBoard(int size = 3)
        {
            Size = size;
            ThreeDGrid = CreateGrid(Size);
        }

        private string[][][] CreateGrid (int size)
        {	
		    string[][][] threeDGrid = new string[size][][];
		
			for(int x=0 ; x<size; x++){
				var layerArray = new string[size][];
				
				for(int y=0 ; y < size ; y++){
					var depthArray = new string[size];
					for(int z=0 ; z< size; z++){
						depthArray[z] = " ";
					}
					layerArray[y] = depthArray;
				}
				threeDGrid[x] = layerArray;
			}
            return threeDGrid;
        }
        
        public string PrintBoard()
        {
            var boardString = "";

            foreach (var row in ThreeDGrid)
            {
                foreach (var col in row)
                {
                    foreach(var depth in col)
                    {
                        if (depth == " ")
                        {
                            boardString += ".";
                        } else
                        {
                            boardString += depth;
                        }
                    }
                    boardString += "\n";
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
            var z = coordArray[2] - 1;
            ThreeDGrid[x][y][z]= token;
        }

        public ValidationMessage CheckForValidCoord(string input)
        {
            try
            {
                var coordArray = input.Split(",").Select(int.Parse).ToArray();
                var not3IntegerNumbersSeparatedByComma = coordArray.Length != 3;

                if (not3IntegerNumbersSeparatedByComma)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var x = coordArray[0] - 1;
                var y = coordArray[1] - 1;
                var z = coordArray[2] - 1;
                var coordIsNegativeNumber = x < 0 || y < 0 || z < 0;

                var coordIsOutsideOfBoard = x >= Size || y >= Size || z >= Size;

                if (coordIsNegativeNumber || coordIsOutsideOfBoard)
                {
                    return ValidationMessage.InvalidCoord;
                }

                var occupiedCoord = ThreeDGrid[x][y][z] != " ";

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
        public GameStatus CheckWinner(string playerToken){

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

            foreach (var row in ThreeDGrid)
            {
                foreach (var col in row)
                {
                    foreach(var depth in col)
                    {
                        if (depth != " ")
                        {
                            occupiedCells += 1;
                        }
                    }
                }
            }
            return occupiedCells;
        }
    
        private List<string[]> GetWinningCombinations()
        {
            var winningCombinations = new List<string[]>();

            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                
                for(int colIndex = 0; colIndex < Size; colIndex++)
                {
                    var winningCombinationZ = new string[Size];
                    var winningCombinationY = new string[Size];
                    var winningCombinationX = new string[Size];

                    for(int depthIndex = 0; depthIndex < Size; depthIndex++)
                    {
                        winningCombinationZ[depthIndex] = ThreeDGrid[rowIndex][colIndex][depthIndex];
                        winningCombinationY[depthIndex] = ThreeDGrid[rowIndex][depthIndex][colIndex];
                        winningCombinationX[depthIndex] = ThreeDGrid[depthIndex][colIndex][rowIndex];
                    }
                    winningCombinations.Add(winningCombinationZ);
                    winningCombinations.Add(winningCombinationY);
                    winningCombinations.Add(winningCombinationX);


                }
            }
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
