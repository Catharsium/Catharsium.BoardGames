using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Interfaces.Events.Interfaces;

public interface IReferee
{
    bool Allows(GameEvent gameEvent);
}