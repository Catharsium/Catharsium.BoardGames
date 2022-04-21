using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class ClosingPairPointsCalculator : IClosingPairPointsCalculator
{
    private readonly ITwinGroupFilter twinGroupFilter;


    public ClosingPairPointsCalculator(ITwinGroupFilter twinGroupFilter)
    {
        this.twinGroupFilter = twinGroupFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        foreach (var stoneGroup in hand.Groups.Where(g => this.twinGroupFilter.Includes(g))) {
            var groupValue = 0;
            if (stoneGroup.Stones.Any(s => s.GetType() == typeof(DragonStone))) {
                groupValue += 2;
            }

            if (stoneGroup.Stones.Any(s => s.GetType() == typeof(WindStone) && s.Number == hand.OwnWindNumber)) {
                groupValue += 2;
            }

            result += groupValue;
        }

        return result;
    }
}