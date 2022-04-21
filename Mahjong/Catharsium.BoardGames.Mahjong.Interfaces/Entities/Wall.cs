using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using System;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Interface.Entities;

public class Wall
{
    private List<Stone> Stones { get; }


    public Wall(List<Stone> stones)
    {
        this.Stones = stones;
    }


    public int GetRemaining()
    {
        var result = this.Stones.Count - 14;
        return Math.Max(0, result);
    }


    public Stone Draw()
    {
        throw new NotImplementedException();
    }


    public Stone DrawFromDeadWall()
    {
        throw new NotImplementedException();
    }
}