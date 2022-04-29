using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models.Events;

public class CrossCellGameEvent : GameEvent
{
    private readonly int row;
    private readonly int column;


    public CrossCellGameEvent(int player, int row, int column)
        : base(player)
    {
        this.row = row;
        this.column = column;
    }
}