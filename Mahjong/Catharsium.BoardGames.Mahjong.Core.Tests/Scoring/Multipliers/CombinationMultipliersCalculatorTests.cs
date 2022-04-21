using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Multipliers;

[TestClass]
public class CombinationMultipliersCalculatorTests : TestFixture<CombinationMultipliersCalculator>
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

    #region GetCombinationMultipliers

    [TestMethod]
    public void CalculateFor_Other_Returns0()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<DragonStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateChow<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<WheelStone>(6));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(7));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_HalfClean_Returns1()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<DragonStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateChow<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(6));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(7));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void CalculateFor_FullClean_Returns3()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateChow<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(6));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(7));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(3, actual);
    }


    [TestMethod]
    public void CalculateFor_HighAndHonors_Returns1()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<DragonStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(1));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(9));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<WheelStone>(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void CalculateFor_HalfCleanWithHighAndHonors_Returns2()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<DragonStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(1));
        hand.Groups.Add(this.StoneGroupFactory.CreateKong<BambooStone>(9));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<DragonStone>(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }

    #endregion
}