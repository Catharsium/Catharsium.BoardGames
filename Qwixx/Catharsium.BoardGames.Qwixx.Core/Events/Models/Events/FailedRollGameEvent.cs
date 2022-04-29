using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models.Events;

public class FailedRollGameEvent : GameEvent
{
    public FailedRollGameEvent(int player)
        : base(player)
    {
    }
}