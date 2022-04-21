using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events.Handlers;

[TestClass]
public class CrossCellEventHandlerTests : TestFixture<CrossCellEventHandler>
{
    #region Fixture

    private static readonly int Player = 1;

    #endregion

    #region CanHandle

    [TestMethod]
    public void CanHandle_SupportedType_ReturnsTrue()
    {
        var actual = this.Target.CanHandle(EventType.CrossSquare);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void CanHandle_UnsupportedType_ReturnsFalse()
    {
        var actual = this.Target.CanHandle(EventType.FailedRoll);
        Assert.IsFalse(actual);
    }

    #endregion

    #region Handle

    [TestMethod]
    public void Handle_NotAllowed_ReturnsNotAllowed()
    {
        var gameEvent = new GameEvent(EventType.CrossSquare, Player);
        this.GetDependency<IReferee>().AllowsCrossCell(Player).Returns(false);

        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(EventResultType.NotAllowed, actual.ResultType);
    }


    [TestMethod]
    public void Handle_Allowed_ReturnsSuccess()
    {
        var gameEvent = new GameEvent(EventType.CrossSquare, Player);
        this.GetDependency<IReferee>().AllowsCrossCell(Player).Returns(true);

        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(EventResultType.Success, actual.ResultType);
    }

    #endregion
}