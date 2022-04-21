using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class ChowPointsCalculator : IChowPointsCalculator
{
    private readonly IChowGroupFilter chowGroupFilter;


    public ChowPointsCalculator(IChowGroupFilter chowGroupFilter)
    {
        this.chowGroupFilter = chowGroupFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        foreach (var stoneGroup in hand.Groups.Where(g => this.chowGroupFilter.Includes(g))) {
            var groupValue = 0;
            if (stoneGroup.Stones.Any(s => s.Origin == Location.PlayerEast)) {
                groupValue += 2;
            }

            result += groupValue;
        }

        return result;
    }
}