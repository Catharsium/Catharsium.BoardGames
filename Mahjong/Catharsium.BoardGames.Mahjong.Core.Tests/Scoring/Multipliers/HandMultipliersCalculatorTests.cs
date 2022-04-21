using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Multipliers;

[TestClass]
public class HandMultipliersCalculatorTests : TestFixture<HandMultipliersCalculator>
{
    #region Fixture

    private StoneGroupFactory StoneGroupFactory { get; set; }


    [TestInitialize]
    public void SetupDependencies()
    {
        this.StoneGroupFactory = new StoneGroupFactory();
        this.SetDependency<IHighStoneFilter>(new HighStoneFilter(new HonorStoneFilter()));
        this.SetDependency<IHonorStoneFilter>(new HonorStoneFilter());
        this.SetDependency<INormalStoneFilter>(new NormalStoneFilter());
        this.SetDependency<IPungGroupFilter>(new PungGroupFilter());
        this.SetDependency<IKongGroupFilter>(new KongGroupFilter());
    }

    #endregion

    #region GetHandMultipliers

    [TestMethod]
    public void CalculateFor_NoMahjong_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_3PungsInHand_Returns1()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5, true));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6, true));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void CalculateFor_4PungsInHand_Returns2()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6, true));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }


    [TestMethod]
    public void CalculateFor_2KongsInHand_Returns1()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(4, true));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(5, true));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6, true));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void CalculateFor_3KongsInHand_Returns2()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(5, true));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6, true));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }


    [TestMethod]
    public void CalculateFor_4KongsInHand_Returns3()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6, true));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(3, actual);
    }


    [TestMethod]
    public void CalculateFor_AllStonesInHand_Returns1()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(5));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }

    #endregion
}