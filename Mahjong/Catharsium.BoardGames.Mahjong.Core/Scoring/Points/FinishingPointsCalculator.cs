using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System;
namespace Catharsium.BoardGames.Mahjong.Core.Scoring.Points;

public class FinishingPointsCalculator : IFinishingPointsCalculator
{
    public int CalculateFor(Hand hand)
    {
        throw new NotImplementedException();
        //- drawn from live wall (2)
        //- had to be this name (2)
        //- last stone before tie (10)
        //- not accepted from dead wall (10)
        //- hoi kong roof (10)
    }
}