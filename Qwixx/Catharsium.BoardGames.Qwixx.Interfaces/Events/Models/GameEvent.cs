using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
namespace Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;

public class GameEvent
{
    public EventType Type { get; set; }
    public int Player { get; set; }
    public object Data { get; set; }


    public GameEvent(EventType type, int player)
    {
        this.Type = type;
        this.Player = player;
    }
}