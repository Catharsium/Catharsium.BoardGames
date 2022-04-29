using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Core;

public class GameEventManager : IGameEventManager
{
    private readonly IReferee referee;
    private readonly IEnumerable<IGameEventHandler> eventHandlers;


    public GameEventManager(IReferee referee, IEnumerable<IGameEventHandler> eventHandlers)
    {
        this.referee = referee;
        this.eventHandlers = eventHandlers;
    }


    public GameEventResult Add(GameEvent gameEvent)
    {
        var eventHandler = this.eventHandlers.Single(eh => eh.CanHandle(gameEvent));
        return this.referee.Allows(gameEvent) ?
            eventHandler.Handle(gameEvent) :
            new GameEventResult(GameEventStatus.NotAllowed);
    }
}