using Catharsium.BoardGames.Core.Interfaces.Events.Models;

namespace Catharsium.BoardGames.Core.Interfaces.Events.Interfaces;

public interface IReferee
{
    bool Allows(GameEvent gameEvent);
}