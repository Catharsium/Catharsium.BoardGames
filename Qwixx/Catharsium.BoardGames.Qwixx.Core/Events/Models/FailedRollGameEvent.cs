using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models;

public class FailedRollGameEvent : GameEvent
{
    public FailedRollGameEvent(int player)
        : base(player)
    {
    }
}