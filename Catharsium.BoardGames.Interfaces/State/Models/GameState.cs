using Catharsium.BoardGames.Interfaces.State.Interfaces;
namespace Catharsium.BoardGames.Interfaces.State.Models;

public abstract class GameState<T> : IGameState<T> where T : Player
{
    public List<T> Players { get; set; }

    public int CurrentPlayer { get; set; }


    public GameState(IEnumerable<T> players)
    {
        this.Players = new List<T>();
        this.Players.AddRange(players);
    }
}