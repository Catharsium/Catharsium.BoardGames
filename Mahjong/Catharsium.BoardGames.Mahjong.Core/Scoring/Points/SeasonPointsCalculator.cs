using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class SeasonPointsCalculator : ISeasonPointsCalculator
{
    public int CalculateFor(Hand hand)
    {
        return hand.Stones
            .Where(s => s.GetType() == typeof(SeasonStone) || s.GetType() == typeof(FlowerStone))
            .Sum(s => 4);
    }
}