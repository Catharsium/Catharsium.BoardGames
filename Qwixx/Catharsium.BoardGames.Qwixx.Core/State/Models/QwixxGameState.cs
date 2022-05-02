using Catharsium.BoardGames.Interfaces.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.State.Models;

public class QwixxGameState : GameState<QwixxPlayer>
{
    public QwixxGameState(IEnumerable<QwixxPlayer> players) : base(players)
    {
    }
}