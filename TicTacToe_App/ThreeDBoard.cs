using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class ThreeDBoard 
    {
        public string[][][] ThreeDGrid{ get; set; }
        public int BoardSize{ get; set; }
        public ThreeDBoard(int boardSize = 3)
        {
            BoardSize = boardSize;
            ThreeDGrid = CreateGrid(BoardSize);
        }

        public string[][][] CreateGrid (int boardSize)
        {		
		    string[][][] threeDGrid = new string[boardSize][][];
		
			for(int x=0 ; x<boardSize; x++){
				var layerArray = new string[boardSize][];
				
				for(int y=0 ; y < boardSize ; y++){
					var depthArray = new string[boardSize];
					for(int z=0 ; z< boardSize; z++){
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

        public ThreeDBoard UpdateBoard(ThreeDBoard currentBoard, string token, string coord)
        {
            var coordArray = coord.Split(",").Select(int.Parse).ToArray();
            var x = coordArray[0] - 1;
            var y = coordArray[1] - 1;
            var z = coordArray[2] - 1;
            currentBoard.ThreeDGrid[x][y][z]= token;

            return currentBoard;

        }
    }
}
