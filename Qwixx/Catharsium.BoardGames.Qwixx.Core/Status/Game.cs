using Catharsium.BoardGames.Qwixx.Interfaces.Status.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Status.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Status;

public class Game : IGame
{
    private Dictionary<int, Player> Players { get; set; }

    public int CurrentPlayer { get; set; }


    public Game()
    {
        this.Players = new Dictionary<int, Player>();
    }
}