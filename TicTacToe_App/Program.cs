using System;
using System.Linq;
namespace TicTacToe_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var boardTypeOpion = RequestBoardTypeOption(Console.WriteLine, Console.ReadLine);
            var boardType = SetBoardType(boardTypeOpion);

            if(boardType == BoardType.TwoD)
            {
                var boardSizeOption = RequestBoardSizeOption(Console.WriteLine, Console.ReadLine);
                var boardSize = SetBoardSize(boardSizeOption);
                var board = new Board(boardSize);

                var maxNumberOfPlayers = CheckMaxNumberOfPlayerAgainstABoardSize(boardSize);

                var numberOfPlayers = RequestNumberOfPlayers(maxNumberOfPlayers, Console.WriteLine, Console.ReadLine);

                var playerList = PlayersChooseToken(numberOfPlayers, Console.WriteLine, Console.ReadLine);

                var newGame = new TicTacToe(boardType, board, playerList, Console.Write, Console.ReadLine);
                
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

                var newGame = new TicTacToe(boardType, threeDBoard, playerList, Console.Write, Console.ReadLine);
                newGame.RunGame();

            }
            
        }
        
        public static int RequestBoardTypeOption(Action<string> write, Func<string> read)
        {
            var boardTypeInput ="";
            while(true)
            {
                write("Please choose the board type with the option below: \n"
                + "1 for 2D Board \n"
                + "2 for 3D Board");

                boardTypeInput = read();

                var validationInput = Rules.CheckForValidBoardTypeOption(boardTypeInput);
                
                if (validationInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid option.");
                }
                else
                {
                    break;
                }
            }
            return int.Parse(boardTypeInput);
        }

        public static BoardType SetBoardType(int boardTypeOption)     
        {
            var boardType = BoardType.TwoD;
            if (boardTypeOption == 1)
            {
                boardType = BoardType.TwoD;
            }
            else 
            {
                boardType = BoardType.ThreeD;
            }
           
            return boardType;
        }
        public static int RequestBoardSizeOption(Action<string> write, Func<string> read)
        {
            var boardSizeInput = "";
            while (true)
            {
                write("Please choose the board size with the option below: \n"
                + "1 for 3x3 board \n"
                + "2 for 4x4 board \n"
                + "3 for 5x5 board");

                boardSizeInput = read();

                var validationInput = Rules.CheckForValidBoardSizeOption(boardSizeInput);
                
                if (validationInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid option.");
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
            var boardSize = 0;
            if (boardSizeOption == 1)
            {
                boardSize = 3;
            }
            else if (boardSizeOption == 2)
            {
                boardSize = 4;
            }
            else
            {
                boardSize = 5;
            }
            return boardSize;
        }
        
        public static int RequestNumberOfPlayers(int maxNumberOfPlayers, Action<string> write, Func<string> read)
        {
            var numberOfPlayersInput = "";
            while (true)
            {
                write("Please enter number of players to play with the rule below: \n"
                + "Minimum is 2 players \n"
                + "Maximum is 4 players \n"
                + "With 3x3 board, only 2 players can play");

                numberOfPlayersInput = read();

                var validationInput = Rules.CheckForValidNumberOfPlayersInput(maxNumberOfPlayers, numberOfPlayersInput);

                if (validationInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid number of players.");
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
                write($"Player {playerIndex + 1} choose a token:");
                var playerTokenInput = read();

                var validationTokenInput = Rules.CheckForValidTokenInput(playerTokenInput);

                if (validationTokenInput == ValidationInput.Invalid)
                {
                    write("Sorry, it's not a valid token.");
                }
                else if (playerList.Any(player => player == playerTokenInput))
                {
                    write("Sorry, the token is already taken. Please choose another one!");
                }
                else
                {
                    return playerTokenInput;
                }
            }
        }

    }
}
