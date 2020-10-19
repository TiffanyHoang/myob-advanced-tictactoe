using System;
using System.Linq;
namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardTypeOption = RequestBoardTypeOption(Console.WriteLine, Console.ReadLine);

            if(boardTypeOption == 1)
            {
                var boardSizeOption = RequestBoardSizeOption(Console.WriteLine, Console.ReadLine);
                var boardSize = SetBoardSize(boardSizeOption);
                var board = new Board(boardSize);

                var maxNumberOfPlayers = CheckMaxNumberOfPlayerAgainstABoardSize(boardSize);

                var numberOfPlayers = RequestNumberOfPlayers(maxNumberOfPlayers, Console.WriteLine, Console.ReadLine);

                var playerList = PlayersChooseToken(numberOfPlayers, Console.WriteLine, Console.ReadLine);

                var newGame = new TicTacToe(board, playerList, Console.Write, Console.ReadLine);
                
                newGame.RunGame();
            } 
            else
            {
                var threeDBoard = new ThreeDBoard();
                var playerList = new string[]
                {
                    "X",
                    "O"
                };

                var newGame = new TicTacToe(threeDBoard, playerList, Console.Write, Console.ReadLine);
                newGame.RunGame();

            }
        }
        
        public static int RequestBoardTypeOption(Action<string> write, Func<string> read)
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

        public static int RequestBoardSizeOption(Action<string> write, Func<string> read)
        {
            var boardSizeInput = "";
            while (true)
            {
                write(GameInstructions.BoardSizeOption());

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
        
        public static int RequestNumberOfPlayers(int maxNumberOfPlayers, Action<string> write, Func<string> read)
        {
            var numberOfPlayersInput = "";
            while (true)
            {
                write(GameInstructions.NumberOfPlayers());

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
        
        public static string[] PlayersChooseToken(int numberOfPlayers, Action<string> write, Func<string> read)
        {
            string[] playerList = new string[numberOfPlayers];
            for (int index = 0; index < numberOfPlayers; index++)
            {
                playerList[index] = GetValidPlayerTokenInput(playerList, index, write , read);
            }

            return playerList;
        }

        private static int CheckMaxNumberOfPlayerAgainstABoardSize(int boardSize)
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
