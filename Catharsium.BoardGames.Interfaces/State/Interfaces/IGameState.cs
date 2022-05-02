using Catharsium.BoardGames.Interfaces.State.Models;
namespace Catharsium.BoardGames.Interfaces.State.Interfaces;

public interface IGameState<T> where T : Player
{
    List<T> Players { get; set; }

    int CurrentPlayer { get; set; }
}