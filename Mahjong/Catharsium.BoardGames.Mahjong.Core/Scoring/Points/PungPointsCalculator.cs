using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class PungPointsCalculator : IPungPointsCalculator
{
    private readonly IPungGroupFilter pungGroupFilter;
    private readonly IHighStoneFilter highStoneFilter;


    public PungPointsCalculator(IPungGroupFilter pungGroupFilter, IHighStoneFilter highStoneFilter)
    {
        this.pungGroupFilter = pungGroupFilter;
        this.highStoneFilter = highStoneFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        foreach (var stoneGroup in hand.Groups.Where(g => this.pungGroupFilter.Includes(g))) {
            var groupValue = 2;
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