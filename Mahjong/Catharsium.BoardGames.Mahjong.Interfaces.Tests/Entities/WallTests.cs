using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Mahjong.Interfaces.Tests.Entities;

[TestClass]
public class WallTests : TestFixture<Wall>
{
    #region GetRemaining

    [TestMethod]
    public void GetRemaining_MoreThan14Stones_ReturnsTotalMinus14()
    {
        var numberOfStones = 20;
        this.SetDependency(GenerateStones(numberOfStones));

        var actual = this.Target.GetRemaining();
        Assert.AreEqual(numberOfStones - 14, actual);
    }


    [TestMethod]
    public void GetRemaining_14Stones_Returns0()
    {
        var numberOfStones = 14;
        this.SetDependency(GenerateStones(numberOfStones));

        var actual = this.Target.GetRemaining();
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetRemaining_LessThan14Stones_Returns0()
    {
        var numberOfStones = 10;
        this.SetDependency(GenerateStones(numberOfStones));

        var actual = this.Target.GetRemaining();
        Assert.AreEqual(0, actual);
    }

    #endregion

    private static List<Stone> GenerateStones(int number)
    {
        var result = new List<Stone>();
        for (var i = 0; i < number; i++) {
            result.Add(new Stone(2));
        }

        return result;
    }
}