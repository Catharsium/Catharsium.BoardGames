using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class KongPointsCalculator : IKongPointsCalculator
{
    private readonly IKongGroupFilter kongGroupFilter;
    private readonly IHighStoneFilter highStoneFilter;


    public KongPointsCalculator(IKongGroupFilter kongGroupFilter, IHighStoneFilter highStoneFilter)
    {
        this.kongGroupFilter = kongGroupFilter;
        this.highStoneFilter = highStoneFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        foreach (var stoneGroup in hand.Groups.Where(g => this.kongGroupFilter.Includes(g))) {
            var groupValue = 8;
            if (stoneGroup.Stones.Any(s => s.Origin == Location.PlayerEast)) {
                groupValue += 2;
            }

            if (this.highStoneFilter.Includes(stoneGroup.Stones.First())) {
                groupValue *= 2;
            }

            if (!stoneGroup.IsOpen) {
                groupValue *= 2;
            }

            result += groupValue;
        }

        return result;
    }
}