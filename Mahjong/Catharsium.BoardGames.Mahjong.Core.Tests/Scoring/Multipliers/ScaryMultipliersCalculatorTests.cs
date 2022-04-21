using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Multipliers;

[TestClass]
public class ScaryMultipliersCalculatorTests : TestFixture<ScaryMultipliersCalculator>
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

    #region GetScaryMultipliers

    [TestMethod]
    public void GetScaryMultipliers_NoMahjong_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_ValidScaryMahjong_Returns1()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, true);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, true);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, true);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, true);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, true);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_NoBambooGroup_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, false);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, true);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, true);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, true);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, true);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_NoSignGroup_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, true);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, false);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, true);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, true);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, true);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_NoWheelGroup_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, true);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, true);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, false);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, true);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, true);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_NoDragonGroupGroup_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, true);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, true);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, true);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, false);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, true);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetScaryMultipliers_NoWindGroupGroup_Returns0()
    {
        var hand = new Hand();
        this.GetDependency<IStandardMahjongFilter>().Includes(hand).Returns(true);

        var bambooGroup = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        this.SetFilter<BambooStone>(bambooGroup, true);
        hand.Groups.Add(bambooGroup);
        var signGroup = this.StoneGroupFactory.CreateKong<SignStone>(3);
        this.SetFilter<SignStone>(signGroup, true);
        hand.Groups.Add(signGroup);
        var wheelGroup = this.StoneGroupFactory.CreateKong<WheelStone>(4);
        this.SetFilter<WheelStone>(wheelGroup, true);
        hand.Groups.Add(wheelGroup);
        var dragonGroup = this.StoneGroupFactory.CreateKong<DragonStone>(1);
        this.SetFilter<DragonStone>(dragonGroup, true);
        hand.Groups.Add(dragonGroup);
        var windStone = this.StoneGroupFactory.CreateKong<WindStone>(2);
        this.SetFilter<WindStone>(windStone, false);
        hand.Groups.Add(windStone);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    private void SetFilter<T>(StoneGroup group, bool returnValue) where T : Stone
    {
        var filter = Substitute.For<IStoneTypeFilter>();
        filter.Includes(group).Returns(returnValue);
        this.GetDependency<IStoneTypeFilterFactory>().CreateFor<T>().Returns(filter);
    }

    #endregion
}