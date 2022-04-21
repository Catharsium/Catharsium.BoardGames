using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Multipliers;

[TestClass]
public class SeasonMultipliersCalculatorTests : TestFixture<SeasonMultipliersCalculator>
{
    #region Calculate

    [TestMethod]
    public void Calculate_NoStones_Returns0()
    {
        var hand = new Hand();
        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void Calculate_NoSeasonSets_Returns0()
    {
        var hand = new Hand();
        hand.Stones.Add(new DragonStone(1));
        hand.Stones.Add(new WindStone(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void Calculate_JustFlowers_Returns0()
    {
        var hand = new Hand();
        hand.Stones.Add(new FlowerStone(1));
        hand.Stones.Add(new FlowerStone(2));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void Calculate_SingleSeasonSet_Returns0()
    {
        var hand = new Hand();
        hand.Stones.Add(new FlowerStone(1));
        hand.Stones.Add(new SeasonStone(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void Calculate_MultipleSeasonSet_ReturnsNumberOfSets()
    {
        var hand = new Hand();
        hand.Stones.Add(new FlowerStone(1));
        hand.Stones.Add(new FlowerStone(2));
        hand.Stones.Add(new FlowerStone(3));
        hand.Stones.Add(new FlowerStone(4));
        hand.Stones.Add(new SeasonStone(1));
        hand.Stones.Add(new SeasonStone(2));
        hand.Stones.Add(new SeasonStone(3));
        hand.Stones.Add(new SeasonStone(4));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(4, actual);
    }

    #endregion
}