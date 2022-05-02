using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Core.Events.Models;
using Catharsium.BoardGames.Qwixx.Core.State;
using Catharsium.BoardGames.Qwixx.Core.State.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events;

[TestClass]
public class RefereeTests : TestFixture<Referee>
{
    #region Fixture

    private CrossCellGameEvent GameEvent { get; set; } = new CrossCellGameEvent(0, 1, 2);


    [TestInitialize]
    public void Initialize()
    {
        this.SetDependency(new GameStateFactory().CreateGameState(3, 3, 3));
    }

    #endregion

    #region Allows 

    [TestMethod]
    public void Allows_CurrentPlayer_ReturnsTrue()
    {
        this.GetDependency<QwixxGameState>().CurrentPlayer = this.GameEvent.Player;
        var actual = this.Target.Allows(this.GameEvent);
        Assert.IsTrue(actual);
    }


    [TestMethod]
    public void Allows_CellIsAlreadyChecked_ReturnsFalse()
    {
        this.GetDependency<QwixxGameState>().CurrentPlayer = this.GameEvent.Player;
        var cell = this.GetDependency<QwixxGameState>()
            .Players.Single(p => p.Id == this.GameEvent.Player)
            .Rows.Single(r => r.Id == this.GameEvent.Row)
            .Cells.Single(c => c.Id == this.GameEvent.Cell);
        cell.IsChecked = true;

        var actual = this.Target.Allows(this.GameEvent);
        Assert.IsFalse(actual);
    }


    [TestMethod]
    public void Allows_OtherPlayer_ReturnsFalse()
    {
        this.GetDependency<QwixxGameState>().CurrentPlayer = this.GameEvent.Player + 1;
        var actual = this.Target.Allows(this.GameEvent);
        Assert.IsFalse(actual);
    }

    #endregion
}