using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Core.Interfaces.Events.Interfaces;

public interface IGameEventHandler
{
    bool CanHandle(GameEventType eventType);
    GameEventResult Handle(GameEvent gameEvent);
}