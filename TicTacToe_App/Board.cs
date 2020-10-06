using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class Board
    {
        public TokenType[][] Grid{ get; set; }
        public int BoardSize{ get; set; }
        public Board(int boardSize = 3)
        {
            BoardSize= boardSize;
            Grid = CreateGrid(BoardSize);
        }

        public TokenType[][] CreateGrid (int boardSize)
        {
            var grid = new TokenType[boardSize][];
            for (int row = 0; row < boardSize; row++)
            {
                var colArray = new TokenType[boardSize];
                for (int col = 0; col < boardSize ; col++)
                {
                    colArray[col] = TokenType.Empty;
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
                    if (cell == TokenType.Empty)
                    {
                        boardString += ".";
                    } else if (cell == TokenType.O)
                    {
                        boardString += "O";
                    } else
                    {
                        boardString += "X";
                    }
                }
                boardString += "\n";
            }
            return boardString;
        }

        public Board UpdateBoard(Board currentBoard, TokenType token, string coord)
        {
            var coordArray = coord.Split(",").Select(int.Parse).ToArray();
            var x = coordArray[0] - 1;
            var y = coordArray[1] - 1;
            currentBoard.Grid[x][y] = token;

            return currentBoard;

        }
    }
}
