using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Core.Events.Models.Events;
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
        var gameEvent = new CrossCellGameEvent(123, 234, 345);
        var actual = this.Target.CanHandle(gameEvent);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void CanHandle_UnsupportedType_ReturnsFalse()
    {
        var gameEvent = new FailedRollGameEvent(123);
        var actual = this.Target.CanHandle(gameEvent);
        Assert.IsFalse(actual);
    }

    #endregion

    #region Handle

    [TestMethod]
    public void Handle_Allowed_ReturnsSuccess()
    {
        var gameEvent = new CrossCellGameEvent(123, 234, 345);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.Success, actual.Status);
    }

    #endregion
}