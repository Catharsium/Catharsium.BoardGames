using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Filters.Hands;

[TestClass]
public class StandardMahjongFilterTests : TestFixture<StandardMahjongFilter>
{
    #region Fixture

    private IStoneGroupFactory StoneGroupFactory { get; set; }


    [TestInitialize]
    public void SetupDependencies()
    {
        this.StoneGroupFactory = new StoneGroupFactory();
        this.SetDependency<ITwinGroupFilter>(new TwinGroupFilter());
    }

    #endregion

    [TestMethod]
    public void Includes_MahjongHand_ReturnsTrue()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6));

        var actual = this.Target.Includes(hand);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_HandWithLooseStones_ReturnsFalse()
    {
        var hand = new Hand();
        hand.Stones.Add(new BambooStone(1));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6));

        var actual = this.Target.Includes(hand);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_HandWith3GroupsAndAClosingPair_ReturnsFalse()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(6));

        var actual = this.Target.Includes(hand);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_HandWith5GroupsAndAClosingPair_ReturnsFalse()
    {
        var hand = new Hand();
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(2));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(3));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(4));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(5));
        hand.Groups.Add(this.StoneGroupFactory.CreatePung<BambooStone>(6));
        hand.Groups.Add(this.StoneGroupFactory.CreateTwin<BambooStone>(7));

        var actual = this.Target.Includes(hand);
        Assert.IsFalse(actual);
    }
}