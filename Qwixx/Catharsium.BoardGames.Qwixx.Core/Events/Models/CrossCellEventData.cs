using Catharsium.BoardGames.Core.Interfaces.Events.Models;
namespace Catharsium.BoardGames.Qwixx.Core.Events.Models;

public class CrossCellEventData : GameEventData
{
    public int Row { get; set; }
    public int Column { get; set; }
}