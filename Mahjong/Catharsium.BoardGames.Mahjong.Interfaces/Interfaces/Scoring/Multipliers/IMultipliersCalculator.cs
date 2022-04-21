using Catharsium.BoardGames.Mahjong.Interface.Entities;

namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;

public interface IMultipliersCalculator
{
    int CalculateFor(Hand hand);
}