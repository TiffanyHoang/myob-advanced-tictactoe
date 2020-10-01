using System;
namespace TicTacToe_App
{
    public enum TokenType
    {
        X,
        O,
        Empty
    }

    public enum GameStatus
    {
        XWin,
        OWin,
        Draw,
        Continue,
        PlayerQuit
    }
}
