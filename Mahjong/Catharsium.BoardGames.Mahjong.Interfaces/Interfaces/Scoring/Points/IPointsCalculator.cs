using Catharsium.BoardGames.Mahjong.Interface.Entities;

namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;

public interface IPointsCalculator
{
    int CalculateFor(Hand hand);
}