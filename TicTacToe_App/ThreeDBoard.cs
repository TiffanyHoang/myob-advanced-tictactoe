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

        public string[] Cells 
        {
            get { return GetCells();}
        }

        public int Size{ get; set; }

        public List<string[]> ResultCombinations 
        {
            get { return GetResultCombinations();}
        }

        public ThreeDBoard(int size = 3)
        {
            Size = size;
            ThreeDGrid = CreateGrid(Size);
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
                        var stringToAppend = depth == " " ? "." : depth;
                        boardString += stringToAppend;
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

        public ValidationMessage CheckCoord(string input)
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

        private string[] GetCells()
        {
            var cols = ThreeDGrid.SelectMany(row => row).ToArray(); 
            var cells = cols.SelectMany(cell => cell).ToArray();

            return cells;
        }

        private List<string[]> GetResultCombinations()
        {
            var resutlCombinations = new List<string[]>();
            var firstCornerLine = new string[Size];
            var secondCornerLine = new string[Size];
            var thirdCornerLine = new string[Size];
            var fourthCornerLine = new string[Size];

            var cornerAntiIndex = Size;

            for (int rowIndex = 0; rowIndex < Size; rowIndex++)
            {
                var XDiagonals = new string[Size];
                var XAntiDiagonals = new string[Size];

                var YDiagonals = new string[Size];
                var YAntiDiagonals = new string[Size];
                var ZDiagonals = new string[Size];
                var ZAntiDiagonals = new string[Size];

                var colIndexAntiDiagonal = Size;

                for(int colIndex = 0; colIndex < Size; colIndex++)
                {
                    var ZEdges = new string[Size];
                    var YEdges = new string[Size];
                    var XEdges = new string[Size];

                    for(int depthIndex = 0; depthIndex < Size; depthIndex++)
                    {
                        ZEdges[depthIndex] = ThreeDGrid[rowIndex][colIndex][depthIndex];
                        YEdges[depthIndex] = ThreeDGrid[rowIndex][depthIndex][colIndex];
                        XEdges[depthIndex] = ThreeDGrid[depthIndex][colIndex][rowIndex];
                    }
                    
                    XDiagonals[colIndex] = ThreeDGrid[rowIndex][colIndex][colIndex];

                    YDiagonals[colIndex] = ThreeDGrid[colIndex][colIndex][rowIndex];
                
                    ZDiagonals[colIndex] = ThreeDGrid[colIndex][rowIndex][colIndex];
                    
                    colIndexAntiDiagonal -= 1;

                    XAntiDiagonals[colIndex] = ThreeDGrid[rowIndex][colIndex][colIndexAntiDiagonal];
                    
                    YAntiDiagonals[colIndex] = ThreeDGrid[colIndex][colIndexAntiDiagonal][rowIndex];
                
                    ZAntiDiagonals[colIndex] = ThreeDGrid[colIndex][rowIndex][colIndexAntiDiagonal];

                    resutlCombinations.Add(ZEdges);
                    resutlCombinations.Add(YEdges);
                    resutlCombinations.Add(XEdges);
                    
                }

                resutlCombinations.Add(XDiagonals);
                resutlCombinations.Add(XAntiDiagonals);
                resutlCombinations.Add(YDiagonals);
                resutlCombinations.Add(YAntiDiagonals);
                resutlCombinations.Add(ZDiagonals);
                resutlCombinations.Add(ZAntiDiagonals);

                firstCornerLine[rowIndex] = ThreeDGrid[rowIndex][rowIndex][rowIndex];
                
                cornerAntiIndex -= 1;

                secondCornerLine[rowIndex] = ThreeDGrid[rowIndex][rowIndex][cornerAntiIndex];
                
                thirdCornerLine[rowIndex] = ThreeDGrid[rowIndex][cornerAntiIndex][rowIndex];
                
                fourthCornerLine[rowIndex] = ThreeDGrid[rowIndex][cornerAntiIndex][cornerAntiIndex];
            }
            
            resutlCombinations.Add(firstCornerLine);
            resutlCombinations.Add(secondCornerLine);
            resutlCombinations.Add(thirdCornerLine);
            resutlCombinations.Add(fourthCornerLine);

            return resutlCombinations;
        }
    }
}
