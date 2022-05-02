using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Handlers;

public class CrossCellEventHandler : IGameEventHandler
{
    private readonly QwixxGameState gameState;


    public CrossCellEventHandler(QwixxGameState gameState)
    {
        this.gameState = gameState;
    }


    public bool CanHandle(GameEvent gameEvent)
    {
        return gameEvent.GetType() == typeof(CrossCellGameEvent);
    }


    public GameEventResult Handle(GameEvent gameEvent)
    {
        if(gameEvent is not CrossCellGameEvent @event) {
            throw new ArgumentException($"{nameof(CrossCellEventHandler)} can only handle a {nameof(CrossCellGameEvent)}");
        }

        var player = this.gameState.Players.FirstOrDefault(p => p.Id == @event.Player);
        if(player == null) {
            return new GameEventResult(GameEventStatus.Failed, $"Player {@event.Player} was not found");
        }

        var row = player.Rows.FirstOrDefault(r => r.Id == @event.Row);
        if(row == null) {
            return new GameEventResult(GameEventStatus.Failed, $"Player {@event.Player}, Row {@event.Row} was not found");
        }

        var cell = row.Cells.FirstOrDefault(c => c.Id == @event.Cell);
        if(cell == null) {
            return new GameEventResult(GameEventStatus.Failed, $"Player {@event.Player}, Row {@event.Row}, Cell {@event.Cell} was not found");
        }

        cell.IsChecked = true;

        return new GameEventResult(GameEventStatus.Success, "");
    }
}