using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Multipliers;

[TestClass]
public class RequiemMultipliersCalculatorTests : TestFixture<RequiemMultipliersCalculator>
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

    #region GetRequiemMultipliers

    [TestMethod]
    public void GetRequiemMultipliers_LastStoneFromDeadWall_Returns1()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5));
        var twin = this.StoneGroupFactory.CreateTwin<BambooStone>(6);
        hand.Groups.Add(twin);
        var lastStone = twin.Stones[0];
        lastStone.Origin = Location.DeadWall;
        hand.LastStone = lastStone;

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(1, actual);
    }

    #endregion
}