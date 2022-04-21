using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.Hands;

public class StandardMahjongFilter : IStandardMahjongFilter
{
    private readonly ITwinGroupFilter twinGroupFilter;


    public StandardMahjongFilter(ITwinGroupFilter twinGroupFilter)
    {
        this.twinGroupFilter = twinGroupFilter;
    }


    public bool Includes(Hand hand)
    {
        if (hand.Stones.Any()) {
            return false;
        }
        if (hand.Groups.Count != 5) {
            return false;
        }
        var twinGroups = hand.Groups.Where(g => this.twinGroupFilter.Includes(g));

        return twinGroups.Count() == 1;
    }
}