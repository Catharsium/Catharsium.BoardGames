using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events;

public class Referee : IReferee
{
    private readonly QwixxGameState gameState;


    public Referee(QwixxGameState gameState)
    {
        this.gameState = gameState;
    }


    public bool Allows(GameEvent gameEvent)
    {
        var result = this.gameState.CurrentPlayer == gameEvent.Player;
        if(gameEvent is CrossCellGameEvent @event) {
            result &= !this.gameState
                .Players.Single(p => p.Id == @event.Player)
                .Rows.Single(r => r.Id == @event.Row)
                .Cells.Single(c => c.Id == @event.Cell)
                .IsChecked;
        };

        return result;
    }
}