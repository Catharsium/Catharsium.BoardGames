using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Filters.Stones;

[TestClass]
public class HonorStoneFilterTests : TestFixture<HonorStoneFilter>
{
    [TestMethod]
    public void Includes_BambooStone_ReturnsFalse()
    {
        var stone = new BambooStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_SignStone_ReturnsFalse()
    {
        var stone = new SignStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_WheelStone_ReturnsFalse()
    {
        var stone = new WheelStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_DragonStone_ReturnsTrue()
    {
        var stone = new DragonStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_WindStone_ReturnsTrue()
    {
        var stone = new WindStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_SeaonStone_ReturnsFalse()
    {
        var stone = new SeasonStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Includes_FlowerStone_ReturnsFalse()
    {
        var stone = new FlowerStone(1);
        var actual = this.Target.Includes(stone);
        Assert.IsFalse(actual);
    }
}