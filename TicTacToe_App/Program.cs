using System;
using System.Linq;
namespace TicTacToe_App
{
    public class Program
    {
        private static int _boardTypeOption = 1;
        private static int _boardSizeOption = 1;
        private static string[] _playerList = new string[]{"X", "O"};
        static void Main(string[] args)
        {
            Start(Console.WriteLine, Console.ReadLine);
        }

        public static void Start( Action<string> write, Func<string> read){
            var game = NewTicTacToeGame(SettingType.New, write, read);
            var gameResult = game.RunGame();
            PlayRound(gameResult, write, read);
        }

        public static void PlayRound(GameStatus gameResult, Action<string> write, Func<string> read)
        {
            while (gameResult == GameStatus.Draw || gameResult == GameStatus.Win)
            {
                var playerDecisionOnNextRound = GetPlayerDecisionOnNextRound(write, read);
                if (playerDecisionOnNextRound == "Y")
                {
                    var playerDecisionOnSettings = GetPlayerDecisionOnSettings(write, read);
                    if (playerDecisionOnSettings == "Y")
                    {
                        var game =  NewTicTacToeGame(SettingType.New, write, read);
                        gameResult = game.RunGame();
                    }
                    else 
                    {
                        var game = NewTicTacToeGame(SettingType.Current, write, read);
                        gameResult = game.RunGame();
                    }
                } 
                else {
                    PrintGoodbyeMessage(Console.WriteLine);
                    break;
                }
            }
        }

        public static TicTacToe NewTicTacToeGame(SettingType settings, Action<string> write, Func<string> read)
        {
            if (settings == SettingType.New)
            {
                _boardTypeOption = GetBoardTypeOption(write, read);

                _boardSizeOption = GetBoardSizeOption(_boardTypeOption, write, read);

                var boardSize = SetBoardSize(_boardSizeOption);

                var board = SetBoard(_boardTypeOption, boardSize);

                var maxNumberOfPlayers = GetMaxNumberOfPlayerForABoard(boardSize);

                var numberOfPlayers = GetNumberOfPlayers(_boardTypeOption, maxNumberOfPlayers, write, read);

                _playerList = GetPlayerList(numberOfPlayers, write, read);

                return new TicTacToe(board,_playerList, write, read);
            }
            else
            {
                var boardSize = SetBoardSize(_boardSizeOption);

                var board = SetBoard(_boardTypeOption, boardSize);
                
                return new TicTacToe(board, _playerList, write, read);
            }
        }

        public static IBoard SetBoard (int boardTypeOption, int boardSize)
        {            
            if(boardTypeOption == 1)
            {
               var board = new Board(boardSize);
               return board;
            }
            else{
               var board = new ThreeDBoard(boardSize);
               return board;
            }
        }

        public static string GetPlayerDecisionOnNextRound(Action<string> write, Func<string> read)
        {
            write(GameInstructions.PlayAgainQuestion());
            return read().ToUpper();
        }

        public static string GetPlayerDecisionOnSettings(Action<string> write, Func<string> read)
        {
            write(GameInstructions.ChangeSettingsQuestion());
            return read().ToUpper();
        }

        public static void PrintGoodbyeMessage(Action<string> write)
        {
            write(GameInstructions.GoodbyeMessage());
        }

        public static int GetBoardTypeOption(Action<string> write, Func<string> read)
        {
            var boardTypeInput ="";
            while(true)
            {
                write(GameInstructions.BoardTypeOption());

                boardTypeInput = read();

                var boardTypeOption = Rules.CheckBoardTypeOption(boardTypeInput);
                
                if (boardTypeOption == ValidationInput.Invalid)
                {
                    write(GameInstructions.InvalidInputMessage());
                }
                else
                {
                    break;
                }

            }
            return int.Parse(boardTypeInput);
        }

        public static int GetBoardSizeOption(int boardTypeOption, Action<string> write, Func<string> read)
        {
            var boardSizeInput = "";
            while (true)
            {
                write(GameInstructions.BoardSizeOption(boardTypeOption));

                boardSizeInput = read();

                var boardSizeOption = Rules.CheckBoardSizeOption(boardSizeInput);
                
                if (boardSizeOption == ValidationInput.Invalid)
                {
                    write(GameInstructions.InvalidInputMessage());
                }
                else
                {
                    break;
                }
            }
            return int.Parse(boardSizeInput);
        }

        public static int SetBoardSize(int boardSizeOption)
        {
            return boardSizeOption switch
            {
                1 => 3,
                2 => 4,
                3 => 5,
                _ => 3
            };
        }
        
        public static int GetNumberOfPlayers(int boardTypeOption, int maxNumberOfPlayers, Action<string> write, Func<string> read)
        {
            var numberOfPlayersInput = "";
            while (true)
            {
                write(GameInstructions.NumberOfPlayers(boardTypeOption));

                numberOfPlayersInput = read();

                var numberOfPlayers = Rules.CheckNumberOfPlayersInput(maxNumberOfPlayers, numberOfPlayersInput);

                if (numberOfPlayers == ValidationInput.Invalid)
                {
                    write(GameInstructions.InvalidInputMessage());
                }
                else
                {
                    break;
                }
            }
            return int.Parse(numberOfPlayersInput);
        }
        
        public static string[] GetPlayerList(int numberOfPlayers, Action<string> write, Func<string> read)
        {
            string[] playerList = new string[numberOfPlayers];
            for (int index = 0; index < numberOfPlayers; index++)
            {
                playerList[index] = GetValidPlayerTokenInput(playerList, index, write , read);
            }

            return playerList;
        }

        private static int GetMaxNumberOfPlayerForABoard(int boardSize)
        {
           return boardSize == 3 ? 2 : 4;
        }
        
        private static string GetValidPlayerTokenInput(string[] playerList, int playerIndex, Action<string> write, Func<string> read)
        {
            while (true)
            {
                write(GameInstructions.PlayerChooseToken(playerIndex));
                var playerTokenInput = read();

                var tokenInput = Rules.CheckTokenInput(playerTokenInput);

                if (tokenInput == ValidationInput.Invalid)
                {
                    write(GameInstructions.InvalidInputMessage());
                }
                else if (playerList.Any(player => player == playerTokenInput))
                {
                    write(GameInstructions.TakenTokenMessage());
                }
                else
                {
                    return playerTokenInput;
                }
            }
        }

    }
}
