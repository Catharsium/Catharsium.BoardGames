using Catharsium.BoardGames.Qwixx.Core.Events.Models.Status;
using Catharsium.BoardGames.Qwixx.Core.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.State;

public class GameStateFactory
{
    public QwixxGameState CreateGameState(int numberOfPlayers, int numberOfRows, int numberOfCells)
    {
        var players = new List<QwixxPlayer>();
        for(var i = 0; i < numberOfPlayers; i++) {
            players.Add(this.CreatePlayer(i, numberOfRows, numberOfCells));
        }

        return new QwixxGameState(players);
    }


    public QwixxPlayer CreatePlayer(int playerId, int numberOfRows, int numberOfCells)
    {
        var rows = new List<Row>();
        for(var row = 0; row < numberOfRows; row++) {
            rows.Add(this.CreateRow(row, numberOfCells));
        }

        return new QwixxPlayer(playerId, $"My player {playerId}", rows);
    }


    public Row CreateRow(int rowId, int numberOfCells)
    {
        var cells = new List<Cell>();
        for(var cell = 0; cell < numberOfCells; cell++) {
            cells.Add(new Cell(cell));
        }

        return new Row(rowId, cells);
    }
}