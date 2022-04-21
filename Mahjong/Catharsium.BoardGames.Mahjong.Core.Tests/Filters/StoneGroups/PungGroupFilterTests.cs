using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Filters.StoneGroups;

[TestClass]
public class PungGroupFilterTests : TestFixture<PungGroupFilter>
{
    #region Fixture

    private StoneGroupFactory StoneGroupFactory { get; set; }


    [TestInitialize]
    public void SetupProperties()
    {
        this.StoneGroupFactory = new StoneGroupFactory();
    }

    #endregion

    [TestMethod]
    public void Includes_Pung_ReturnsTrue()
    {
        var group = this.StoneGroupFactory.CreatePung<BambooStone>(2);
        var actual = this.Target.Includes(group);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Includes_NotAPung_ReturnsFalse()
    {
        var group = this.StoneGroupFactory.CreateKong<BambooStone>(2);
        var actual = this.Target.Includes(group);
        Assert.IsFalse(actual);
    }
}