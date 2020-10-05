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
            var isXTurn = true;

            var currentPlayer = isXTurn ? TokenType.X : TokenType.O;

            _write("Welcome to Tic Tac Toe!\nHere's the current board:\n");

            _write(_board.PrintBoard());

            while (true)
            {
                currentPlayer = isXTurn ? TokenType.X : TokenType.O;
                var playerInput = "";
                while (true)
                { 
                    playerInput = RequestInput(currentPlayer);

                    if (playerInput == "q")
                    {
                        _write($"{currentPlayer} quit!");
                        return GameStatus.PlayerQuit;
                    }
                    
                    var checkCoord = Rules.CheckForValidCoord(_board, playerInput);

                    if (checkCoord == ValidationMessage.InvalidCoord)
                    {
                        _write("Oh no, it's not a valid coord! Try again... \n");
                    }
                    else if (checkCoord == ValidationMessage.OccupiedCell)
                    {
                        _write("Oh no, a piece is already at this place! Try again... \n");
                    }

                    checkCoord = Rules.CheckForValidCoord(_board, playerInput);
                    
                    if (checkCoord == ValidationMessage.ValidCoord)
                    {
                        break;
                    }
                }

                _board.UpdateBoard(_board, currentPlayer, playerInput);

                PrintUpdateBoard();

                var gameResult = GameResult.CheckWinner(_board);

                if (gameResult == GameStatus.XWin)
                {
                    _write("Player X win!");
                    return GameStatus.XWin;
                }

                if (gameResult == GameStatus.OWin)
                {
                    _write("Player O win!");
                    return GameStatus.OWin;
                }

                if (gameResult == GameStatus.Draw)
                {
                    _write("Draw!");
                    return GameStatus.Draw;
                }

                isXTurn = !isXTurn;

            }

        }

        private void PrintInstruction(TokenType player)
        {
            _write($"Player {player} enter a coord x,y to place your {player} or enter 'q' to give up:");
        }

        private string RequestInput(TokenType currentPlayer)
        {
            PrintInstruction(currentPlayer);
            return _read();
        }

        private void PrintUpdateBoard()
        {
            _write("Move accepted, here's the current board: \n");
            _write(_board.PrintBoard());
        }

    }
}
