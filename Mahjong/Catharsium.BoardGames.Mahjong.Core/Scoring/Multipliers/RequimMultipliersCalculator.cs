using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class RequiemMultipliersCalculator : IRequiemMultipliersCalculator
{
    public int CalculateFor(Hand hand)
    {
        var lastStone = hand.LastStone;
        return lastStone?.Origin == Location.DeadWall
            ? 1
            : 0;
    }
}