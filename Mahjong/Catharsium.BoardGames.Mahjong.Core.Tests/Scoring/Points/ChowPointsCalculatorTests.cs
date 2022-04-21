using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Enum;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Scoring.Points;

[TestClass]
public class ChowPointsCalculatorTests : TestFixture<ChowPointsCalculator>
{
    #region CalculateFor

    [TestMethod]
    public void CalculateFor_NoChow_Returns0()
    {
        var group = new StoneGroupFactory().CreateChow<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IChowGroupFilter>().Includes(group).Returns(false);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_SingleChow_Returns0()
    {
        var group = new StoneGroupFactory().CreateChow<BambooStone>(2, true);
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IChowGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void CalculateFor_FirstDiscardFromEast_Returns2()
    {
        var group = new StoneGroupFactory().CreateChow<BambooStone>(2, true);
        group.Stones[2].Origin = Location.PlayerEast;
        var hand = new Hand();
        hand.Groups.Add(group);
        this.GetDependency<IChowGroupFilter>().Includes(group).Returns(true);

        var actual = this.Target.CalculateFor(hand);
        Assert.AreEqual(2, actual);
    }

    #endregion
}