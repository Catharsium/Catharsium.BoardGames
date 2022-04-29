using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.Events.Models.Events;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Handlers;

public class CrossCellEventHandler : IGameEventHandler
{
    public CrossCellEventHandler()
    {
    }


    public bool CanHandle(GameEvent gameEvent)
    {
        return gameEvent.GetType() == typeof(CrossCellGameEvent);
    }


    public GameEventResult Handle(GameEvent gameEvent)
    {
        return new GameEventResult(GameEventStatus.Incomplete, "");
    }
}