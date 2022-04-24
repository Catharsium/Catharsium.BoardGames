using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Handlers;

public class QwixxEventManager : IGameEventManager
{
    private readonly IReferee referee;
    private readonly IEnumerable<IGameEventHandler> eventHandlers;


    public QwixxEventManager(IReferee referee, IEnumerable<IGameEventHandler> eventHandlers)
    {
        this.referee = referee;
        this.eventHandlers = eventHandlers;
    }


    public GameEventResult Add(GameEvent gameEvent)
    {
        var eventHandler = this.eventHandlers.Single(eh => eh.CanHandle(gameEvent.Type));
        return this.referee.Allows(gameEvent) ?
            eventHandler.Handle(gameEvent) :
            new GameEventResult(GameEventResultType.NotAllowed);
    }
}