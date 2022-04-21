using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;

public class KongGroupFilter : IKongGroupFilter
{
    public bool Includes(StoneGroup group)
    {
        var referenceStone = group.Stones.First();
        return group.Stones.Count == 4 && group.Stones.All(s => s.Equals(referenceStone));
    }
}