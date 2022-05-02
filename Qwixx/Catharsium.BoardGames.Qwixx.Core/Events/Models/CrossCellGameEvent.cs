using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models;

public class CrossCellGameEvent : GameEvent
{
    public int Row { get; }

    public int Cell { get; }


    public CrossCellGameEvent(int player, int row, int column)
        : base(player)
    {
        this.Row = row;
        this.Cell = column;
    }
}