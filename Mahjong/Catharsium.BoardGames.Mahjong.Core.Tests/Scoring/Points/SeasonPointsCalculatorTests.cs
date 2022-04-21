using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Points;

[TestClass]
public class SeasonPointsCalculatorTests : TestFixture<SeasonPointsCalculator>
{
    #region GetSeasonPoints

    [TestMethod]
    public void CalculateFor_NoSeasons_Returns0()
    {
        var hand = new Hand();
        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_OnlySeasons_ReturnsNumberOfSeasonsTimes4()
    {
        var hand = new Hand();
        hand.Stones.Add(new FlowerStone(1));
        hand.Stones.Add(new SeasonStone(2));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(hand.Stones.Count * 4, actual);
    }


    [TestMethod]
    public void CalculateFor_SeasonsWithOtherStones_ReturnsNumberOfSeasonsTimes4()
    {
        var hand = new Hand();
        hand.Stones.Add(new FlowerStone(1));
        hand.Stones.Add(new SeasonStone(2));
        hand.Stones.Add(new DragonStone(3));
        hand.Stones.Add(new WindStone(4));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2 * 4, actual);
    }

    #endregion
}