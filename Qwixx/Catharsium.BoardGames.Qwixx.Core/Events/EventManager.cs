using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events;

public class EventManager : IEventManager
{
    private readonly IReferee referee;
    private readonly IEnumerable<IGameEventHandler> eventHandlers;


    public EventManager(IReferee referee, IEnumerable<IGameEventHandler> eventHandlers)
    {
        this.referee = referee;
        this.eventHandlers = eventHandlers;
    }


    public EventResult Add(GameEvent gameEvent)
    {
        var eventHandler = this.eventHandlers.Single(eh => eh.CanHandle(gameEvent.Type));
        return eventHandler.Handle(gameEvent);
    }
}