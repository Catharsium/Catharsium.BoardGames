using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
namespace Catharsium.BoardGames.Core.Interfaces.Events.Models;

public class GameEvent
{
    public GameEventType Type { get; set; }
    public int Player { get; set; }
    public GameEventData Data { get; set; }


    public GameEvent(GameEventType type, int player)
    {
        this.Type = type;
        this.Player = player;
    }
}