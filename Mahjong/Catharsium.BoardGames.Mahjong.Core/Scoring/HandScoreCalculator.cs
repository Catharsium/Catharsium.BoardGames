using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Scoring;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using System;
using System.Collections.Generic;

namespace Catharsium.BoardGames.Mahjong.Core.Scoring;

public class HandScoreCalculator : IHandScoreCalculator
{
    private readonly IEnumerable<IPointsCalculator> pointsCalculators;
    private readonly IEnumerable<IMultipliersCalculator> multipliersCalculators;


    public HandScoreCalculator(IEnumerable<IPointsCalculator> pointsCalculators, IEnumerable<IMultipliersCalculator> multipliersCalculators)
    {
        this.pointsCalculators = pointsCalculators;
        this.multipliersCalculators = multipliersCalculators;
    }


    public ScoreCard Calculate(Hand hand)
    {
        var result = new ScoreCard();
        var totalPoints = 0;
        foreach (var calculator in this.pointsCalculators) {
            var points = calculator.CalculateFor(hand);
            result.AddCategory(calculator.GetType().Name, points);
            totalPoints += points;
        }

        var totalMultipliers = 0;
        foreach (var calculator in this.multipliersCalculators) {
            var multipliers = calculator.CalculateFor(hand);
            result.AddCategory(calculator.GetType().Name, multipliers);
            totalMultipliers += multipliers;
        }

        result.Total = totalPoints * (int)Math.Pow(2, totalMultipliers);
        return result;
    }
}