using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.Util.Filters;
using System;
namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;

public interface IStoneTypeFilter : IFilter<StoneGroup>
{
    Type Type { get; }
}