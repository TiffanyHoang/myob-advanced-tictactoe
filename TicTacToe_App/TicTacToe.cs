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

        public GameStatus RunGame()
        {
            var isXTurn = false;

            var currentPlayer = isXTurn ? TokenType.X : TokenType.O;

            _write("Welcome to Tic Tac Toe!\nHere's the current board:\n");

            _write(_board.PrintBoard());

            var gameResult = GameResult.CheckWinner(_board);

            while (true)
            {
                isXTurn = !isXTurn;

                currentPlayer = isXTurn ? TokenType.X : TokenType.O;

                PrintInstruction(currentPlayer);

                var playerInput = _read();

                var isValidCoord = Rules.CheckForValidCoord(_board, playerInput);

                if (playerInput == "q")
                {
                    return GameStatus.PlayerQuit;
                }


                while (!isValidCoord)
                {
                    _write("Opps, it's not a valid coord! Try again... \n");

                    PrintInstruction(currentPlayer);
                    playerInput = _read();

                    isValidCoord = Rules.CheckForValidCoord(_board, playerInput);

                    if (playerInput == "q")
                    {
                        return GameStatus.PlayerQuit;
                    }
                }

                currentPlayer = isXTurn ? TokenType.X : TokenType.O;
                _board.UpdateBoard(_board, currentPlayer, playerInput);

                gameResult = GameResult.CheckWinner(_board);
                _write(_board.PrintBoard());


                if (gameResult == GameStatus.XWin)
                {
                    _write("Player X win");
                    return GameStatus.XWin;

                }

                else if ( gameResult == GameStatus.OWin)
                {
                    _write("Player O win");
                    return GameStatus.OWin;

                }

                else if (gameResult == GameStatus.Draw)
                {
                    _write("Draw");
                    return GameStatus.Draw;
                }
            }

        }

        private void PrintInstruction(TokenType player)
        {
            _write($"Player {player} enter a coord x,y to place your {player} or enter 'q' to give up:");
        }

        
    }
}
