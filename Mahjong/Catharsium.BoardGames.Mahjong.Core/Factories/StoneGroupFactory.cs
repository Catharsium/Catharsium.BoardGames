using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using System;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Core.Factories;

public class StoneGroupFactory : IStoneGroupFactory
{
    public StoneGroup CreateChow<T>(int number, bool isOpen = false) where T : Stone
    {
        return new StoneGroup {
            Stones = new List<Stone> {
                (T)Activator.CreateInstance(typeof(T), number),
                (T)Activator.CreateInstance(typeof(T), number + 1),
                (T)Activator.CreateInstance(typeof(T), number + 2)
            },
            IsOpen = isOpen
        };
    }


    public StoneGroup CreateTwin<T>(int number, bool isOpen = false) where T : Stone
    {
        return CreateGroupOfEqualStones<T>(2, number, isOpen);
    }


    public StoneGroup CreatePung<T>(int number, bool isOpen = false) where T : Stone
    {
        return CreateGroupOfEqualStones<T>(3, number, isOpen);
    }


    public StoneGroup CreateKong<T>(int number, bool isOpen = false) where T : Stone
    {
        return CreateGroupOfEqualStones<T>(4, number, isOpen);
    }


    private static StoneGroup CreateGroupOfEqualStones<T>(int stoneCount, int number, bool isOpen) where T : Stone
    {
        var result = new StoneGroup {
            Stones = new List<Stone>(),
            IsOpen = isOpen
        };
        for (var i = 0; i < stoneCount; i++) {
            result.Stones.Add((T)Activator.CreateInstance(typeof(T), number));
        }

        return result;
    }
}