using System;
namespace TicTacToe_App
{
    public enum ValidationMessage
    {
        ValidCoord,
        InvalidCoord,
        OccupiedCell
    }

    public enum GameStatus
    {
        Win,
        Draw,
        Continue,
        PlayerQuit
    }

    public enum ValidationInput
    {
        Valid,
        Invalid
    }

    public enum BoardType
    {
        TwoD,
        ThreeD,
    }

    public enum SettingType
    {
        Current,
        New
    }
}
