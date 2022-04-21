using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using System;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;

public class StoneTypeFilter<T> : IStoneTypeFilter where T : Stone
{
    public Type Type => typeof(T);


    public bool Includes(StoneGroup group)
    {
        return group.Stones.All(s => s.GetType() == this.Type);
    }
}