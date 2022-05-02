using Catharsium.BoardGames.Interfaces.State.Models;
namespace Catharsium.BoardGames.Qwixx.Core.State.Models;

public class QwixxPlayer : Player
{
    public List<Row> Rows { get; set; }


    public QwixxPlayer(int id, string name, IEnumerable<Row> rows) : base(id, name)
    {
        this.Rows = new List<Row>();
        this.Rows.AddRange(rows);
    }
}