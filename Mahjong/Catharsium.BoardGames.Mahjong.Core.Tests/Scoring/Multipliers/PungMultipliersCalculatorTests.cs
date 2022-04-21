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
public class PungMultipliersCalculatorTests : TestFixture<PungMultipliersCalculator>
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

    #region CalculateFor

    [TestMethod]
    public void GetPungMultipliers_Dragon_Returns1()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<DragonStone>(2));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void GetPungMultipliers_OwnWind_Returns1()
    {
        var hand = new Hand { OwnWindNumber = 2 };
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(2));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void GetPungMultipliers_EastWind_Returns1()
    {
        var hand = new Hand { OwnWindNumber = 2 };
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }


    [TestMethod]
    public void GetPungMultipliers_EastWindWhenAndOwnWind_Returns2()
    {
        var hand = new Hand { OwnWindNumber = 1 };
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }


    [TestMethod]
    public void GetPungMultipliers_OtherWind_Returns0()
    {
        var hand = new Hand { OwnWindNumber = 2 };
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WindStone>(3));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetPungMultipliers_NormalStone_Returns0()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<WheelStone>(1));

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }

    #endregion
}