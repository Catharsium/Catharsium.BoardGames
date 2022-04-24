using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
namespace Catharsium.BoardGames.Core.Interfaces.Events.Models;

public class GameEventResult
{
    public GameEventResultType ResultType { get; set; }
    public string Message { get; set; }


    public GameEventResult(GameEventResultType resultType) : this(resultType, "")
    { }


    public GameEventResult(GameEventResultType resultType, string message)
    {
        this.ResultType = resultType;
        this.Message = message;
    }
}