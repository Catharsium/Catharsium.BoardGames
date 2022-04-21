using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Points;

[TestClass]
public class ClosingPairPointsCalculatorTests : TestFixture<ClosingPairPointsCalculator>
{
    #region CalculateFor

    [TestMethod]
    public void CalculateFor_NoPair_Returns0()
    {
        var group = new StoneGroupFactory().CreateTwin<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<ITwinGroupFilter>().Includes(group).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_NoDragonOrWind_Returns0()
    {
        var group = new StoneGroupFactory().CreateTwin<BambooStone>(9, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<ITwinGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_DragonPair_Returns2()
    {
        var group = new StoneGroupFactory().CreateTwin<DragonStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<ITwinGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }


    [TestMethod]
    public void CalculateFor_OtherWindPair_Returns0()
    {
        var windNumber = 2;
        var group = new StoneGroupFactory().CreateTwin<WindStone>(windNumber, true);
        var hand = new Hand {
            OwnWindNumber = windNumber + 1
        };
        hand.Groups.Add(group);
        this.GetDependency<ITwinGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_OwnWindPair_Returns2()
    {
        var windNumber = 2;
        var group = new StoneGroupFactory().CreateTwin<WindStone>(windNumber, true);
        var hand = new Hand {
            OwnWindNumber = windNumber
        };
        hand.Groups.Add(group);
        this.GetDependency<ITwinGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }

    #endregion
}