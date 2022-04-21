using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Interface.Entities;

public class StoneGroup
{
    public List<Stone> Stones { get; set; }
    public bool IsOpen { get; set; }
}