using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Status.Interfaces;
namespace Catharsium.BoardGames.Qwixx.Core.Events;

public class Referee : IReferee
{
    private readonly IGame game;


    public Referee(IGame game)
    {
        this.game = game;
    }


    public bool AllowsCrossCell(int player)
    {
        return this.game.CurrentPlayer == player;
    }
}