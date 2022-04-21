using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Points;

[TestClass]
public class FinishingPointsCalculatorTests : TestFixture<FinishingPointsCalculator>
{
    [TestMethod]
    [Ignore]
    public void CalculateFor_()
    {
        var hand = new Hand();
        this.Target.CalculateFor(hand);
    }
}