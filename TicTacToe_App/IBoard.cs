using System;
using System.Collections.Generic;

namespace TicTacToe_App
{
    public interface IBoard
    {
        public BoardType Type {get;}
        
        public string[] Cells {get; }

        public int Size{ get; set; }

        public List<string[]> ResultCombinations {get;}
       
        public string PrintBoard();

        public void UpdateBoard(string token, string coord);

        public ValidationMessage CheckCoord(string input);

    }
}
