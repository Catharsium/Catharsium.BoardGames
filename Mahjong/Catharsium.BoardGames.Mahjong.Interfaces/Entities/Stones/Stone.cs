using Catharsium.BoardGames.Mahjong.Interface.Enum;
using System;
namespace Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;

public class Stone : IEquatable<Stone>
{
    public int Number { get; set; }
    public Location Origin { get; set; }


    public Stone(int number)
    {
        this.Number = number;
    }


    public override bool Equals(object obj)
    {
        return obj is Stone other && this.Equals(other);
    }


    public bool Equals(Stone other)
    {
        return other != null && this.Number == other.Number;
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(this.Number);
    }
}