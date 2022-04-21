using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;

public interface IStoneTypeFilterFactory
{
    IStoneTypeFilter CreateFor<T>() where T : Stone;
}