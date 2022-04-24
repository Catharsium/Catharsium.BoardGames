using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Handlers;

public class CrossCellEventHandler : IGameEventHandler
{
    public CrossCellEventHandler()
    {
    }


    public bool CanHandle(GameEventType eventType)
    {
        return eventType == GameEventType.CrossSquare;
    }


    public GameEventResult Handle(GameEvent gameEvent)
    {
        return new GameEventResult(GameEventResultType.Incomplete, "");
    }
}