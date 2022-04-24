namespace Catharsium.BoardGames.Core.Interfaces.State.Models;

public abstract class GameState
{
    private Dictionary<int, Player> Players { get; set; }

    public int CurrentPlayer { get; set; }


    public GameState()
    {
        this.Players = new Dictionary<int, Player>();
    }
}