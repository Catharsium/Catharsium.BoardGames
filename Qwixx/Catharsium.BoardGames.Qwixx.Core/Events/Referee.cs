using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.BoardGames.Interfaces.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events;

public class Referee : IReferee
{
    private readonly GameState game;


    public Referee(GameState game)
    {
        this.game = game;
    }


    public bool Allows(GameEvent gameEvent)
    {
        return this.game.CurrentPlayer == gameEvent.Player;
    }
}