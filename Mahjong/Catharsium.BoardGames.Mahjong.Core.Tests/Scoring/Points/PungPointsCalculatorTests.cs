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
public class PungPointsCalculatorTests : TestFixture<PungPointsCalculator>
{
    #region CalculateFor

    [TestMethod]
    public void CalculateFor_NoPungs_Returns0()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(false);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleOpenLowValuePung_Returns2()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleOpenHighValuePung_Returns4()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(4, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleClosedLowValuePung_Returns4()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(4, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleClosedHighValuePung_Returns8()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(8, actual);
    }


    [TestMethod]
    public void CalculateFor_MultiplePungs_ReturnsSum()
    {
        var firstPung = new StoneGroupFactory().CreatePung<BambooStone>(1);
        var secondPung = new StoneGroupFactory().CreatePung<SignStone>(2);
        var hand = new Hand();
        hand.Groups.Add(firstPung);
        hand.Groups.Add(secondPung);
        this.GetDependency<IPungGroupFilter>().Includes(firstPung).Returns(true);
        this.GetDependency<IPungGroupFilter>().Includes(secondPung).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<BambooStone>()).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<SignStone>()).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(12, actual);
    }


    [TestMethod]
    public void CalculateFor_FirstDiscardFromEast_Returns()
    {
        var group = new StoneGroupFactory().CreatePung<BambooStone>(2);
        group.Stones[2].Origin = Location.PlayerEast;
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IPungGroupFilter>().Includes(group).Returns(true);
        this.GetDependency<IHighStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(16, actual);
    }

    #endregion
}