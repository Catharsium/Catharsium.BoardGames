using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Interfaces.Events.Interfaces;

public interface IGameEventHandler
{
    bool CanHandle(GameEvent eventType);
    GameEventResult Handle(GameEvent gameEvent);
}