using System;


namespace TicTacToe_App
{
    public class TicTacToe
    {
        private readonly Board _board;
        private readonly Action<string> _write;
        private readonly Func<string> _read;

        private readonly string[] _playerList;

        public TicTacToe(Board board, string[] playerList, Action<string> write, Func<string> read)
        {
            _board = board;
            _playerList = playerList;
            _write = write;
            _read = read;
        }

        public GameStatus RunGame()
        {
            _write("Welcome to Tic Tac Toe!\nHere's the current board:\n");

            _write(_board.PrintBoard());

            while (true)
            {
                for(int playerIndex = 0 ; playerIndex < _playerList.Length; playerIndex++)
                {
                    var currentPlayer = _playerList[playerIndex];

                    var validInput = CheckCurrentPlayerInput(currentPlayer, playerIndex);

                    if (validInput == "q")
                    {
                        _write($"{currentPlayer} quit!");
                        return GameStatus.PlayerQuit;
                    } 

                    _board.UpdateBoard(_board, currentPlayer, validInput);

                    PrintUpdateBoard();

                    var gameResult = GameResult.CheckWinner(_board, currentPlayer);

                    if (gameResult == GameStatus.Win)
                    {
                        _write($"Player {playerIndex + 1} win!");
                        return GameStatus.Win;
                    }

                    if (gameResult == GameStatus.Draw)
                    {
                        _write("Draw!");
                        return GameStatus.Draw;
                    }
                }
            }
        }

        private void PrintInstruction(string currentPlayer, int playerIndex)
        {
            _write($"Player {playerIndex + 1} enter a coord x,y to place your {currentPlayer} or enter 'q' to give up:");
        }

        private string RequestInput(string currentPlayer, int playerIndex)
        {
            PrintInstruction(currentPlayer, playerIndex);
            return _read();
        }

        private void PrintUpdateBoard()
        {
            _write("Move accepted, here's the current board: \n");
            _write(_board.PrintBoard());
        }

        private string CheckCurrentPlayerInput (string currentPlayer, int playerIndex)
        {
            var playerInput = "";
            while (true)
            { 
                playerInput = RequestInput(currentPlayer, playerIndex);

                if (playerInput == "q")
                {
                    return playerInput;
                }
                
                var checkCoord = Rules.CheckForValidCoord(_board, playerInput);

                if (checkCoord == ValidationMessage.InvalidCoord)
                {
                    _write("Oh no, it's not a valid coord! Try again... \n");
                }
                else if (checkCoord == ValidationMessage.OccupiedCell)
                {
                    _write("Oh no, a piece is already at this place! Try again... \n");
                } else 
                {
                    break;
                }
            }
            return playerInput;
        }
    }
}
