using System;
using System.Linq;
namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardTypeOption = GetBoardTypeOption(Console.WriteLine, Console.ReadLine);

            var boardSizeOption = GetBoardSizeOption(boardTypeOption, Console.WriteLine, Console.ReadLine);

            var boardSize = SetBoardSize(boardSizeOption);

            var board = SetBoard(boardTypeOption, boardSize);

            var maxNumberOfPlayers = GetMaxNumberOfPlayerForABoard(boardSize);
            var numberOfPlayers = GetNumberOfPlayers(boardTypeOption, maxNumberOfPlayers, Console.WriteLine, Console.ReadLine);
            var playerList = GetPlayerList(numberOfPlayers, Console.WriteLine, Console.ReadLine);

            var newGame = new TicTacToe(board, playerList, Console.Write, Console.ReadLine);
            var gameResult = newGame.RunGame();

            while (gameResult == GameStatus.Draw || gameResult == GameStatus.Win)
            {
                var playerDecisionOnNextRound = GetPlayerDecisionOnNextRound(Console.WriteLine);
                if (playerDecisionOnNextRound == "Y")
                {
                    var playerDecisionOnSettings = GetPlayerDecisionOnSettings(Console.WriteLine);
                    if (playerDecisionOnSettings == "Y")
                    {
                        boardTypeOption = GetBoardTypeOption(Console.WriteLine, Console.ReadLine);

                        boardSizeOption = GetBoardSizeOption(boardTypeOption, Console.WriteLine, Console.ReadLine);

                        boardSize = SetBoardSize(boardSizeOption);

                        board = SetBoard(boardTypeOption, boardSize);

                        maxNumberOfPlayers = GetMaxNumberOfPlayerForABoard(boardSize);
                        numberOfPlayers = GetNumberOfPlayers(boardTypeOption, maxNumberOfPlayers, Console.WriteLine, Console.ReadLine);
                        playerList = GetPlayerList(numberOfPlayers, Console.WriteLine, Console.ReadLine);

                        newGame = new TicTacToe(board, playerList, Console.Write, Console.ReadLine);
                        gameResult = newGame.RunGame();
                    }
                    else 
                    {
                        board = SetBoard(boardTypeOption, boardSize);
                        newGame = new TicTacToe(board, playerList, Console.Write, Console.ReadLine);
                        gameResult = newGame.RunGame();
                    }
                } 
                else {
                    PrintGoodbyeMessage(Console.WriteLine);
                    break;
                }
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

        public static string GetPlayerDecisionOnNextRound(Action<string> write)
        {
            write(GameInstructions.PlayAgainQuestion());
            return Console.ReadLine().ToUpper();
        }

        public static string GetPlayerDecisionOnSettings(Action<string> write)
        {
            write(GameInstructions.ChangeSettingsQuestion());
            return Console.ReadLine().ToUpper();
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
