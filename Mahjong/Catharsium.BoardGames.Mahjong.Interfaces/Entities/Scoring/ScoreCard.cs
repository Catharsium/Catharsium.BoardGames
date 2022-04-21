using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Interface.Entities.Scoring;

public class ScoreCard
{
    public int Total { get; set; }

    private Dictionary<string, int> categories;
    public Dictionary<string, int> Categories => this.categories ??= new Dictionary<string, int>();


    public void AddCategory(string name, int points)
    {
        if (this.Categories.ContainsKey(name)) {
            this.Categories[name] = points;
        }
        else {
            this.Categories.Add(name, points);
        }
    }
}