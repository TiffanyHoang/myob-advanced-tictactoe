using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public class Board
    {
        public TokenType[][] Grid{ get; set; }

        public Board()
        {
            Grid = new TokenType[][] {
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty },
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty },
               new TokenType[] { TokenType.Empty, TokenType.Empty, TokenType.Empty }
            };
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
