namespace Catharsium.BoardGames.Interfaces.Events.Models;

public class GameEvent
{
    public int Player { get; set; }


    public GameEvent(int player)
    {
        this.Player = player;
    }
}