using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using System.Collections.Generic;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Factories;

public class StoneTypeFilterFactory : IStoneTypeFilterFactory
{
    private readonly IEnumerable<IStoneTypeFilter> stoneTypeFilters;


    public StoneTypeFilterFactory(IEnumerable<IStoneTypeFilter> stoneTypeFilters)
    {
        this.stoneTypeFilters = stoneTypeFilters;
    }


    public IStoneTypeFilter CreateFor<T>() where T : Stone
    {
        return this.stoneTypeFilters.FirstOrDefault(f => f.Type == typeof(T));
    }
}