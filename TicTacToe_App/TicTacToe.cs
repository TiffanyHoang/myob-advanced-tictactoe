using System;


namespace TicTacToe_App
{
    public class TicTacToe
    {
        private readonly IBoard _board;
        private readonly Action<string> _write;
        private readonly Func<string> _read;

        private readonly string[] _playerList;

        public TicTacToe(IBoard board, string[] playerList, Action<string> write, Func<string> read)
        {
            _board = board;
            _playerList = playerList;
            _write = write;
            _read = read;
        }

        public GameStatus RunGame()
        {
            _write(GameInstructions.WelcomeMessage(_board.Type));
            
            _write(_board.PrintBoard());

            while (true)
            {
                for(int playerIndex = 0 ; playerIndex < _playerList.Length; playerIndex++)
                {
                    var currentPlayer = _playerList[playerIndex];

                    var validInput = CheckCurrentPlayerInput(currentPlayer, playerIndex);

                    if (validInput == "q")
                    {
                        _write(GameInstructions.PlayerQuitMessage(playerIndex));
                        return GameStatus.PlayerQuit;
                    } 

                    _board.UpdateBoard(currentPlayer, validInput);

                    PrintUpdateBoard();

                    var gameResult = _board.CheckWinner(currentPlayer);

                    if (gameResult == GameStatus.Win)
                    {
                        _write(GameInstructions.PlayerWinMessage(playerIndex));
                        return GameStatus.Win;
                    }

                    if (gameResult == GameStatus.Draw)
                    {
                        _write(GameInstructions.DrawGameMessage());
                        return GameStatus.Draw;
                    }
                }
            }
        }

        private void PrintUpdateBoard()
        {
            _write(GameInstructions.MoveAcceptedMessage());
            _write(_board.PrintBoard());
        }

        private string CheckCurrentPlayerInput (string currentPlayer, int playerIndex)
        {
            var playerInput = "";
            while (true)
            { 
                _write(GameInstructions.EnterInputMessage(_board.Type, playerIndex, currentPlayer));

                playerInput = _read();

                if (playerInput == "q")
                {
                    return playerInput;
                }
                
                var coord = _board.CheckForValidCoord(playerInput);

                if (coord == ValidationMessage.InvalidCoord)
                {
                    _write(GameInstructions.InvalidCoordMessage());
                }
                else if (coord == ValidationMessage.OccupiedCell)
                {
                    _write(GameInstructions.OccupiedCellMessage());
                } else 
                {
                    break;
                }
            }
            return playerInput;
        }
    }
}
