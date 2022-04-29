using Catharsium.BoardGames.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Tests._Fixture;

public class MockGameEvent : GameEvent
{
    public MockGameEvent(int player) : base(player)
    {
    }
}