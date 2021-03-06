namespace Catharsium.BoardGames.Interfaces.State.Models;

public abstract class Player
{
    public int Id { get; }

    public string Name { get; }


    public Player(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}