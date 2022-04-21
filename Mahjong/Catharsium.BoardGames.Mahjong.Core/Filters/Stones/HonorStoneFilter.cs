using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
namespace Catharsium.BoardGames.Mahjong.Core.Filters.Stones;

public class HonorStoneFilter : IHonorStoneFilter
{
    public bool Includes(Stone stone)
    {
        var type = stone.GetType();
        return type == typeof(DragonStone) ||
               type == typeof(WindStone);
    }
}