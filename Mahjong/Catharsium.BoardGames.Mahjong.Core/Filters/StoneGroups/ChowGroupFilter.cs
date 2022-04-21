using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;

public class ChowGroupFilter : IChowGroupFilter
{
    public bool Includes(StoneGroup group)
    {
        if (group.Stones.Count != 3) {
            return false;
        }

        var referenceStone = group.Stones.First();
        var number = referenceStone.Number;
        return group.Stones.All(stone => stone.Number == number++);
    }
}