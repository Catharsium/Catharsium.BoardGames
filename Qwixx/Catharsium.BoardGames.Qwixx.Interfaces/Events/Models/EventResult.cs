using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
namespace Catharsium.BoardGames.Qwixx.Interfaces.Events.Models;

public class EventResult
{
    public EventResultType ResultType { get; set; }
    public string Message { get; set; }


    public EventResult(EventResultType resultType, string message)
    {
        this.ResultType = resultType;
        this.Message = message;
    }
}