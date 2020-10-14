using System;

namespace TicTacToe_App
{
    public interface IBoard
    {
        public int BoardSize{ get; set; }

        public string PrintBoard();

        public void UpdateBoard(string token, string coord);

        public ValidationMessage CheckForValidCoord(string input);

        public GameStatus CheckWinner(string playerToken);

    }
}
