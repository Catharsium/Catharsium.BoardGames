using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Interfaces.Status.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events;

[TestClass]
public class RefereeTests : TestFixture<Referee>
{
    #region Fixture

    private static readonly int CurrentPlayer = 0;

    #endregion

    #region Allows 

    [TestMethod]
    public void AllowsCrossCell_CurrentPlayer_ReturnsTrue()
    {
        this.GetDependency<IGame>().CurrentPlayer.Returns(CurrentPlayer);
        var actual = this.Target.AllowsCrossCell(CurrentPlayer);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void AllowsCrossCell_OtherPlayer_ReturnsFalse()
    {
        this.GetDependency<IGame>().CurrentPlayer.Returns(CurrentPlayer);
        var actual = this.Target.AllowsCrossCell(CurrentPlayer + 1);
        Assert.IsFalse(actual);
    }

    #endregion
}