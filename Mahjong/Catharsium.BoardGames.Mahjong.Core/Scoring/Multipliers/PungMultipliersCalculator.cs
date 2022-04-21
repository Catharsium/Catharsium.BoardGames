using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;

public class PungMultipliersCalculator : IPungMultipliersCalculator
{
    public int CalculateFor(Hand hand)
    {
        var result = 0;
        foreach (var group in hand.Groups) {
            var type = group.Stones.First().GetType();
            if (type == typeof(DragonStone)) {
                result += 1;
            }

            if (type != typeof(WindStone)) {
                continue;
            }

            if (group.Stones.First().Number == hand.OwnWindNumber) {
                result += 1;
            }

            if (group.Stones.First().Number == 1) {
                result += 1;
            }
        }

        return result;
    }
}