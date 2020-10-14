using System;


namespace TicTacToe_App
{
    public class TicTacToe
    {
        private readonly IBoard _board;
        private readonly BoardType _boardType;

        private readonly Action<string> _write;
        private readonly Func<string> _read;

        private readonly string[] _playerList;

        public TicTacToe(BoardType boardType, IBoard board, string[] playerList, Action<string> write, Func<string> read)
        {
            _board = board;
            _boardType = boardType;
            _playerList = playerList;
            _write = write;
            _read = read;
        }

        public GameStatus RunGame()
        {
            if(_boardType == BoardType.TwoD)
            {
                _write("Welcome to 2D Tic Tac Toe!\nHere's the current board:\n");
            } 
            else
            {
                _write("Welcome to 3D Tic Tac Toe!\nHere's the current board:\n");
            }

            _write(_board.PrintBoard());

            while (true)
            {
                for(int playerIndex = 0 ; playerIndex < _playerList.Length; playerIndex++)
                {
                    var currentPlayer = _playerList[playerIndex];

                    var validInput = CheckCurrentPlayerInput(_boardType, currentPlayer, playerIndex);

                    if (validInput == "q")
                    {
                        _write($"Player {playerIndex + 1} quit!");
                        return GameStatus.PlayerQuit;
                    } 

                    _board.UpdateBoard(currentPlayer, validInput);

                    PrintUpdateBoard();

                    var gameResult = _board.CheckWinner(currentPlayer);

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

        private void PrintInstruction(BoardType boardType, string currentPlayer, int playerIndex)
        {
            if(_boardType == BoardType.TwoD)
                {
                    _write($"Player {playerIndex + 1} enter a coord x,y to place your {currentPlayer} or enter 'q' to give up:");
                } 
                else
                {
                    _write($"Player {playerIndex + 1} enter a coord x,y,z to place your {currentPlayer} or enter 'q' to give up:");
                }
        }

        private string RequestInput(BoardType boardType, string currentPlayer, int playerIndex)
        {
            PrintInstruction(boardType, currentPlayer, playerIndex);
            return _read();
        }

        private void PrintUpdateBoard()
        {
            _write("Move accepted, here's the current board: \n");
            _write(_board.PrintBoard());
        }

        private string CheckCurrentPlayerInput (BoardType boardType, string currentPlayer, int playerIndex)
        {
            var playerInput = "";
            while (true)
            { 
                playerInput = RequestInput(boardType, currentPlayer, playerIndex);

                if (playerInput == "q")
                {
                    return playerInput;
                }
                
                var checkCoord = _board.CheckForValidCoord(playerInput);

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
