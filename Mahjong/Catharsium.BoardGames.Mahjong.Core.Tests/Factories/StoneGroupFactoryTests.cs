using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Factories;

[TestClass]
public class StoneGroupFactoryTests : TestFixture<StoneGroupFactory>
{
    #region CreateChow

    [TestMethod]
    public void CreateChow_CreatesStoneGroupWith3ConsecutiveStones()
    {
        var number = 2;
        var actual = this.Target.CreateChow<WheelStone>(number);
        Assert.AreEqual(3, actual.Stones.Count);
        Assert.IsFalse(actual.IsOpen);
        foreach (var stone in actual.Stones) {
            Assert.AreEqual(typeof(WheelStone), stone.GetType());
            Assert.AreEqual(number++, stone.Number);
        }
    }


    [TestMethod]
    public void CreateChow_SetsIsOpen()
    {
        var number = 2;
        var actual = this.Target.CreateChow<WheelStone>(number, true);
        Assert.AreEqual(3, actual.Stones.Count);
        Assert.IsTrue(actual.IsOpen);
    }

    #endregion

    #region CreateTwin

    [TestMethod]
    public void CreateTwin_CreatesStoneGroupWith3ConsecutiveStones()
    {
        var number = 3;
        var actual = this.Target.CreateTwin<WheelStone>(number);
        Assert.AreEqual(2, actual.Stones.Count);
        Assert.IsFalse(actual.IsOpen);
        foreach (var stone in actual.Stones) {
            Assert.AreEqual(typeof(WheelStone), stone.GetType());
            Assert.AreEqual(number, stone.Number);
        }
    }


    [TestMethod]
    public void CreateTwin_SetsIsOpen()
    {
        var number = 3;
        var actual = this.Target.CreateTwin<WheelStone>(number, true);
        Assert.AreEqual(2, actual.Stones.Count);
        Assert.IsTrue(actual.IsOpen);
    }

    #endregion

    #region CreatePung

    [TestMethod]
    public void CreatePung_CreatesStoneGroupWith3IdenticalStones()
    {
        var number = 4;
        var actual = this.Target.CreatePung<BambooStone>(number);
        Assert.AreEqual(3, actual.Stones.Count);
        Assert.IsFalse(actual.IsOpen);
        foreach (var stone in actual.Stones) {
            Assert.AreEqual(typeof(BambooStone), stone.GetType());
            Assert.AreEqual(number, stone.Number);
        }
    }


    [TestMethod]
    public void CreatePung_SetsIsOpen()
    {
        var number = 4;
        var actual = this.Target.CreatePung<BambooStone>(number, true);
        Assert.AreEqual(3, actual.Stones.Count);
        Assert.IsTrue(actual.IsOpen);
    }

    #endregion

    #region CreateKong

    [TestMethod]
    public void CreateKong_CreatesStoneGroupWith4IdenticalStones()
    {
        var number = 5;
        var actual = this.Target.CreateKong<SignStone>(number);
        Assert.IsFalse(actual.IsOpen);
        Assert.AreEqual(4, actual.Stones.Count);
        foreach (var stone in actual.Stones) {
            Assert.AreEqual(typeof(SignStone), stone.GetType());
            Assert.AreEqual(number, stone.Number);
        }
    }


    [TestMethod]
    public void CreateKong_SetsIsOpen()
    {
        var number = 5;
        var actual = this.Target.CreateKong<SignStone>(number, true);
        Assert.AreEqual(4, actual.Stones.Count);
        Assert.IsTrue(actual.IsOpen);
    }

    #endregion
}