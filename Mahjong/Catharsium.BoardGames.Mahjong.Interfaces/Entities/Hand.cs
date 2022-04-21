using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Interface.Entities;

public class Hand
{
    private List<Stone> stones;
    public List<Stone> Stones => this.stones ??= new List<Stone>();


    private List<StoneGroup> groups;
    public List<StoneGroup> Groups => this.groups ??= new List<StoneGroup>();


    public Stone LastStone { get; set; }
    public int OwnWindNumber { get; set; }
}