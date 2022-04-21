using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace Catharsium.BoardGames.Mahjong.Interfaces.Tests.Entities;

[TestClass]
public class HandTests : TestFixture<Hand>
{
    [TestMethod]
    public void Stones_ReturnsEmptyList()
    {
        var actual = this.Target.Stones;
        Assert.IsNotNull(actual);
        Assert.IsTrue(!actual.Any());
    }


    [TestMethod]
    public void Groups_ReturnsEmptyList()
    {
        var actual = this.Target.Groups;
        Assert.IsNotNull(actual);
        Assert.IsTrue(!actual.Any());
    }
}