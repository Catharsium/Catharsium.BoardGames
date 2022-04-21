using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class SeasonMultipliersCalculator : ISeasonMultipliersCalculator
{
    public int CalculateFor(Hand hand)
    {
        var flowerStones = hand.Stones.Where(s => s.GetType() == typeof(FlowerStone)).ToList();
        var seasonStones = hand.Stones.Where(s => s.GetType() == typeof(SeasonStone)).ToList();
        return flowerStones.Count(flower => seasonStones.Any(season => season.Number == flower.Number));
    }
}