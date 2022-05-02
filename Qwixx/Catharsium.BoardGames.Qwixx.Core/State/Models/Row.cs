using Catharsium.BoardGames.Qwixx.Core.Events.Models.Status;
namespace Catharsium.BoardGames.Qwixx.Core.State.Models;

public class Row
{
    public int Id { get; }
    public List<Cell> Cells { get; }


    public Row(int id, IEnumerable<Cell> cells)
    {
        this.Id = id;
        this.Cells = new List<Cell>();
        this.Cells.AddRange(cells);
    }
}