using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;

namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;

public interface IStoneGroupFactory
{
    StoneGroup CreateChow<T>(int number, bool isOpen = false) where T : Stone;
    StoneGroup CreateTwin<T>(int number, bool isOpen = false) where T : Stone;
    StoneGroup CreateKong<T>(int number, bool isOpen = false) where T : Stone;
    StoneGroup CreatePung<T>(int number, bool isOpen = false) where T : Stone;
}