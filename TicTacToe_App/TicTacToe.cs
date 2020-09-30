using System;


namespace TicTacToe_App
{
    public class TicTacToe
    {
        private readonly Board _board;
        private readonly Action<string> _write;
        private readonly Func<string> _read;

        public TicTacToe(Board board, Action<string> write, Func<string> read)
        {
            _board = board;
            _write = write;
            _read = read;
        }

        public void RunGame()
        {   
            var playerX = TokenType.X;
            var playerO = TokenType.O;

            var currentPlayer = playerX;

            _write("Welcome to Tic Tac Toe!\nHere's the current board:\n");

            _write(_board.PrintBoard());

            PrintInstruction(currentPlayer);

            var playerInput = _read();

            if (playerInput == "q")
            {
                return;
            }
            else
            {
                var isValidCoord = Rules.CheckForValidCoord(_board, playerInput);

                if (isValidCoord == true)
                {
                    _board.UpdateBoard(_board, currentPlayer, playerInput);
                    _write(_board.PrintBoard());
                    var gameResult = GameResult.CheckWinner(_board);
                    
                } else
                {
                    _write("Opps, it's not a valid coord! Try again... \n");
                    PrintInstruction(currentPlayer);

                }
            }
        }

        private void PrintInstruction(TokenType player)
        {
            _write($"Player {player} enter a coord x,y to place your X or enter 'q' to give up:");
        }
    }
}
