using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.Stones;

public class HighStoneFilter : IHighStoneFilter
{
    private readonly IHonorStoneFilter honorStoneFilter;


    public HighStoneFilter(IHonorStoneFilter honorStoneFilter)
    {
        this.honorStoneFilter = honorStoneFilter;
    }


    public bool Includes(Stone stone)
    {
        return this.honorStoneFilter.Includes(stone) || stone.Number == 1 || stone.Number == 9;
    }
}