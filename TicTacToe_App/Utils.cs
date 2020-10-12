using System;
namespace TicTacToe_App
{
    public enum TokenType
    {
        X,
        O,
        Empty
    }

    public enum ValidationMessage
    {
        ValidCoord,
        InvalidCoord,
        OccupiedCell
    }

    public enum GameStatus
    {
        Win,
        XWin,
        OWin,
        Draw,
        Continue,
        PlayerQuit
    }

    public enum ValidationInput
    {
        Valid,
        Invalid

    }
}
