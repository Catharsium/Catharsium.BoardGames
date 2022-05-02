using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Core.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.State;
using Catharsium.BoardGames.Qwixx.Core.State.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events.Handlers;

[TestClass]
public class CrossCellEventHandlerTests : TestFixture<CrossCellEventHandler>
{
    #region Fixture

    [TestInitialize]
    public void Initialize()
    {
        this.SetDependency(new GameStateFactory().CreateGameState(3, 3, 3));
    }

    #endregion

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
    public void Handle_UnknownPlayer_ReturnsFailed()
    {
        var gameEvent = new CrossCellGameEvent(123, 1, 2);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.Failed, actual.Status);
        Assert.IsTrue(actual.Message.Contains("123"));
    }


    [TestMethod]
    public void Handle_UnknownRow_ReturnsFailed()
    {
        var gameEvent = new CrossCellGameEvent(0, 123, 2);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.Failed, actual.Status);
        Assert.IsTrue(actual.Message.Contains("123"));
    }


    [TestMethod]
    public void Handle_UnknownCell_ReturnsFailed()
    {
        var gameEvent = new CrossCellGameEvent(0, 1, 123);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.Failed, actual.Status);
        Assert.IsTrue(actual.Message.Contains("123"));
    }


    [TestMethod]
    public void Handle_ValidAction_UpdatesCell_ReturnsSuccess()
    {
        var gameEvent = new CrossCellGameEvent(0, 1, 2);
        var actual = this.Target.Handle(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.Success, actual.Status);
        foreach(var player in this.GetDependency<QwixxGameState>().Players) {
            foreach(var row in player.Rows) {
                foreach(var cell in row.Cells) {
                    if(player.Id == 0 && row.Id == 1 && cell.Id == 2) {
                        Assert.IsTrue(cell.IsChecked);
                    }
                    else {
                        Assert.IsFalse(cell.IsChecked);
                    }
                }
            }
        }
    }

    #endregion
}