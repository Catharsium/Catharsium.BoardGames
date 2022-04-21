using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class ScaryMultipliersCalculator : IScaryMultipliersCalculator
{
    private readonly IStandardMahjongFilter standardMahjongFilter;
    private readonly IStoneTypeFilterFactory stoneTypeFilterFactory;


    public ScaryMultipliersCalculator(IStandardMahjongFilter standardMahjongFilter, IStoneTypeFilterFactory stoneTypeFilterFactory)
    {
        this.standardMahjongFilter = standardMahjongFilter;
        this.stoneTypeFilterFactory = stoneTypeFilterFactory;
    }


    public int CalculateFor(Hand hand)
    {
        if (!this.standardMahjongFilter.Includes(hand)) { return 0; }

        var bambooFilter = this.stoneTypeFilterFactory.CreateFor<BambooStone>();
        if (hand.Groups.Count(g => bambooFilter.Includes(g)) != 1) { return 0; }

        var wheelFilter = this.stoneTypeFilterFactory.CreateFor<WheelStone>();
        if (hand.Groups.Count(g => wheelFilter.Includes(g)) != 1) { return 0; }

        var signFilter = this.stoneTypeFilterFactory.CreateFor<SignStone>();
        if (hand.Groups.Count(g => signFilter.Includes(g)) != 1) { return 0; }

        var windFilter = this.stoneTypeFilterFactory.CreateFor<WindStone>();
        if (hand.Groups.Count(g => windFilter.Includes(g)) != 1) { return 0; }

        var dragonFilter = this.stoneTypeFilterFactory.CreateFor<DragonStone>();
        if (hand.Groups.Count(g => dragonFilter.Includes(g)) != 1) { return 0; }

        return 1;
    }
}