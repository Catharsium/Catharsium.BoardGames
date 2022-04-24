using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events.Handlers;

[TestClass]
public class CrossCellEventHandlerTests : TestFixture<CrossCellEventHandler>
{
    #region CanHandle

    [TestMethod]
    public void CanHandle_SupportedType_ReturnsTrue()
    {
        var actual = this.Target.CanHandle(GameEventType.CrossSquare);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void CanHandle_UnsupportedType_ReturnsFalse()
    {
        var actual = this.Target.CanHandle(GameEventType.FailedRoll);
        Assert.IsFalse(actual);
    }

    #endregion

    #region Handle

    [TestMethod]
    public void Handle_Allowed_ReturnsSuccess()
    {
        var gameEvent = new GameEvent(GameEventType.CrossSquare, 123);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventResultType.Success, actual.ResultType);
    }

    #endregion
}