using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe_App
{
    public interface IBoard
    {
        
        public string[][] CreateGrid (int boardSize);
        
        public string PrintBoard();

        public Board UpdateBoard(IBoard currentBoard, string token, string coord);
    }
}
