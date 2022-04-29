using Catharsium.BoardGames.Interfaces.Events.Enums;
namespace Catharsium.BoardGames.Interfaces.Events.Models;

public class GameEventResult
{
    public GameEventStatus Status { get; set; }
    public string Message { get; set; }


    public GameEventResult(GameEventStatus status)
        : this(status, "")
    { }


    public GameEventResult(GameEventStatus status, string message)
    {
        this.Status = status;
        this.Message = message;
    }
}