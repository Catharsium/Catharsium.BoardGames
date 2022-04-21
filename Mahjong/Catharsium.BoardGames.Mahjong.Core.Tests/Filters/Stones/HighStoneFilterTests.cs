using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Filters.Stones;

[TestClass]
public class HighStoneFilterTests : TestFixture<HighStoneFilter>
{
    [TestInitialize]
    public void SetupDependencies()
    {
        this.GetDependency<IHonorStoneFilter>().Includes(Arg.Any<Stone>()).Returns(false);
    }


    [TestMethod]
    public void Includes_Normal1_ReturnsTrue()
    {
        var stone = new BambooStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_Normal2_ReturnsFalse()
    {
        var stone = new BambooStone(2);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_Normal9_ReturnsTrue()
    {
        var stone = new BambooStone(9);
        var actual = this.Target.Includes(stone);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_HonorStone_ReturnsTrue()
    {
        this.GetDependency<IHonorStoneFilter>().Includes(Arg.Any<Stone>()).Returns(true);
        var stone = new WindStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsTrue(actual);
    }
}