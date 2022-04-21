using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Points;

[TestClass]
public class KongPointsCalculatorTests : TestFixture<KongPointsCalculator>
{
    #region CalculateFor

    [TestMethod]
    public void CalculateFor_NoKongs_Returns0()
    {
        var group = new StoneGroupFactory().CreateKong<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleOpenLowValueKong_Returns8()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(8, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleOpenHighValuePung_Returns16()
    {
        var group = new StoneGroupFactory().CreateKong<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(16, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleClosedLowValuePung_Returns16()
    {
        var group = new StoneGroupFactory().CreateKong<BambooStone>(2);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(16, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleClosedHighValuePung_Returns32()
    {
        var group = new StoneGroupFactory().CreateKong<BambooStone>(2);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(32, actual);
    }


    [TestMethod]
    public void CalculateFor_MultipleKongs_ReturnsSum()
    {
        var firstKong = new StoneGroupFactory().CreateKong<BambooStone>(1);
        var secondKong = new StoneGroupFactory().CreateKong<SignStone>(2);
        var hand = new Hand();
        hand.Groups.Add(firstKong);
        hand.Groups.Add(secondKong);
        this.GetDependency<IKongGroupFilter>().Includes(firstKong).Returns(true);
        this.GetDependency<IKongGroupFilter>().Includes(secondKong).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<BambooStone>()).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<SignStone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(48, actual);
    }


    [TestMethod]
    public void CalculateFor_FirstDiscardFromEast_Adds2()
    {
        var group = new StoneGroupFactory().CreateKong<BambooStone>(2);
        group.Stones[3].Origin = Location.PlayerEast;
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IKongGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(40, actual);
    }

    #endregion
}