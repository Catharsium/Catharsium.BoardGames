using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.Util.Filters;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class HandMultipliersCalculator : IHandMultipliersCalculator
{
    private readonly IStandardMahjongFilter standardMahjongFilter;
    private readonly IPungGroupFilter pungGroupFilter;
    private readonly IKongGroupFilter kongGroupFilter;


    public HandMultipliersCalculator(IStandardMahjongFilter standardMahjongFilter, IPungGroupFilter pungGroupFilter,
        IKongGroupFilter kongGroupFilter)
    {
        this.standardMahjongFilter = standardMahjongFilter;
        this.pungGroupFilter = pungGroupFilter;
        this.kongGroupFilter = kongGroupFilter;
    }


    public int CalculateFor(Hand hand)
    {
        var result = 0;
        if (!this.standardMahjongFilter.Includes(hand)) { return result; }

        if (!hand.Groups.Any(g => g.IsOpen)) {
            result += 1;
        }

        var closedGroups = hand.Groups.Where(g => !g.IsOpen).ToArray();
        var pungGroups = closedGroups.Include(this.pungGroupFilter).ToList();
        switch (pungGroups.Count) {
            case 3:
                result += 1;
                break;
            case 4:
                result += 2;
                break;
        }

        var kongGroups = closedGroups.Include(this.kongGroupFilter).ToList();
        switch (kongGroups.Count) {
            case 2:
                result += 1;
                break;
            case 3:
                result += 2;
                break;
            case 4:
                result += 3;
                break;
        }

        return result;
    }
}