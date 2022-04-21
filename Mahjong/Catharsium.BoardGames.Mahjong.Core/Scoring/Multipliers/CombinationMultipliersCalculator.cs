using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.Util.Filters;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class CombinationMultipliersCalculator : ICombinationMultipliersCalculator
{
    private readonly IHighStoneFilter highStoneFilter;
    private readonly IHonorStoneFilter honorStoneFilter;
    private readonly INormalStoneFilter normalStoneFilter;


    public CombinationMultipliersCalculator(
        IHighStoneFilter highStoneFilter,
        IHonorStoneFilter honorStoneFilter,
        INormalStoneFilter normalStoneFilter)
    {
        this.highStoneFilter = highStoneFilter;
        this.honorStoneFilter = honorStoneFilter;
        this.normalStoneFilter = normalStoneFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        var allStones = hand.Groups.SelectMany(g => g.Stones).ToList();
        allStones.AddRange(hand.Stones);
        var normalStones = allStones.Include(this.normalStoneFilter).ToList();
        var honorStones = allStones.Include(this.honorStoneFilter).ToList();
        if (!normalStones.Any()) {
            result += 3;
        }

        if (!honorStones.Any()) {
            result += 3;
        }

        var normalStoneGroup = normalStones.GroupBy(s => s.GetType());
        if (honorStones.Any() && normalStoneGroup.Count() == 1) {
            result += 1;
        }

        var lowStones = allStones.Exclude(this.highStoneFilter);
        if (!lowStones.Any()) {
            result += 1;
        }

        return result;
    }
}