using Catharsium.BoardGames.Mahjong.Core.Scoring;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring;

[TestClass]
public class HandScoreCalculatorTests : TestFixture<HandScoreCalculator>
{
    [TestMethod]
    public void Calculate_ReturnsTotalPointsTimesTwoToThePowerOfTotalMultipliers()
    {
        var hand = new Hand();
        var pointsCalculator1 = Substitute.For<IPointsCalculator>();
        pointsCalculator1.CalculateFor(hand).Returns(3);
        var pointsCalculator2 = Substitute.For<IPointsCalculator>();
        pointsCalculator2.CalculateFor(hand).Returns(4);
        this.SetDependency<IEnumerable<IPointsCalculator>>(new List<IPointsCalculator> {
            pointsCalculator1,
            pointsCalculator2
        });

        var multipliersCalculator1 = Substitute.For<IMultipliersCalculator>();
        multipliersCalculator1.CalculateFor(hand).Returns(1);
        var multipliersCalculator2 = Substitute.For<IMultipliersCalculator>();
        multipliersCalculator2.CalculateFor(hand).Returns(2);
        this.SetDependency<IEnumerable<IMultipliersCalculator>>(new List<IMultipliersCalculator> {
            multipliersCalculator1,
            multipliersCalculator2
        });

        var actual = this.Target.Calculate(hand);
        Assert.AreEqual(7 * 2 * 2 * 2, actual.Total);
    }
}