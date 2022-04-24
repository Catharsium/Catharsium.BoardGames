using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models;

public class CrossCellGameEvent : GameEvent
{
    public CrossCellGameEvent(int player) : base(GameEventType.CrossSquare, player)
    {
    }
}