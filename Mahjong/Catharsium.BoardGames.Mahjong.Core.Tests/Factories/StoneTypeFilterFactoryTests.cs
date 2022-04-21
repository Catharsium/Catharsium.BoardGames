using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Core.Tests.Factories;

[TestClass]
public class StoneTypeFilterFactoryTests : TestFixture<StoneTypeFilterFactory>
{
    [TestMethod]
    public void CreateFor_ReturnsFilterForStoneType()
    {
        var expected = new StoneTypeFilter<DragonStone>();
        var filters = new List<IStoneTypeFilter> {
            expected
        };
        this.SetDependency<IEnumerable<IStoneTypeFilter>>(filters);

        var actual = this.Target.CreateFor<DragonStone>();
        Assert.AreEqual(expected, actual);
    }
}