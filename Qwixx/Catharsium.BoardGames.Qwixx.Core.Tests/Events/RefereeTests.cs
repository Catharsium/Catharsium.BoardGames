using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.BoardGames.Interfaces.State.Models;
using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Core.Events.Models.Status;
using Catharsium.BoardGames.Qwixx.Core.Tests._Fixture;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events;

[TestClass]
public class RefereeTests : TestFixture<Referee>
{
    #region Fixture

    private GameEvent GameEvent { get; set; }
    private GameState GameState { get; set; }


    [TestInitialize]
    public void Initialize()
    {
        this.GameEvent = new MockGameEvent(123);
        this.GameState = new QwixxGame();
        this.SetDependency(this.GameState);
    }

    #endregion

    #region Allows 

    [TestMethod]
    public void Allows_CurrentPlayer_ReturnsTrue()
    {
        this.GameState.CurrentPlayer = this.GameEvent.Player;
        var actual = this.Target.Allows(this.GameEvent);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Allows_OtherPlayer_ReturnsFalse()
    {
        this.GameState.CurrentPlayer = this.GameEvent.Player + 1;
        var actual = this.Target.Allows(this.GameEvent);
        Assert.IsFalse(actual);
    }

    #endregion
}