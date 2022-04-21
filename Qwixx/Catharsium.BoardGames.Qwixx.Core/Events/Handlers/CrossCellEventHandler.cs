using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Handlers;

public class CrossCellEventHandler : IGameEventHandler
{
    private readonly IReferee referee;


    public CrossCellEventHandler(IReferee referee)
    {
        this.referee = referee;
    }


    public bool CanHandle(EventType eventType)
    {
        return eventType == EventType.CrossSquare;
    }


    public EventResult Handle(GameEvent gameEvent)
    {
        var resultType = EventResultType.NotAllowed;
        if (this.referee.AllowsCrossCell(gameEvent.Player)) {
            resultType = EventResultType.Success;
        }

        return new EventResult(resultType, "");
    }
}