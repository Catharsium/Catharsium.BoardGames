using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;

public interface IGameEventHandler
{
    bool CanHandle(EventType eventType);
    EventResult Handle(GameEvent gameEvent);
}