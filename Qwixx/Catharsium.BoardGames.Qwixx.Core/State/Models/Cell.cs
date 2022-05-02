namespace Catharsium.BoardGames.Qwixx.Core.Events.Models.Status;

public class Cell
{
    public int Id;
    public bool IsChecked { get; set; }


    public Cell(int id)
    {
        this.Id = id;
    }
}