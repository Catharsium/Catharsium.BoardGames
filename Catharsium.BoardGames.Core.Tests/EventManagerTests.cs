using Catharsium.BoardGames.Core.Tests._Fixture;
using Catharsium.BoardGames.Interfaces.Events.Enums;
using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.Events.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Core.Tests;

[TestClass]
public class EventManagerTests : TestFixture<GameEventManager>
{
    #region Fixture

    private readonly GameEvent GameEvent = new MockGameEvent(123);
    private readonly IGameEventHandler GameEventHandler = Substitute.For<IGameEventHandler>();


    [TestInitialize]
    public void Initialize()
    {
        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler });
    }

    #endregion

    #region Add

    [TestMethod]
    public void Add_SingleHandlerThatCanHandle_ReturnsHandlerResult()
    {
        this.GameEventHandler.CanHandle(this.GameEvent).Returns(true);
        var expected = new GameEventResult(GameEventStatus.Success, "My message");
        this.GameEventHandler.Handle(this.GameEvent).Returns(expected);
        this.GetDependency<IReferee>().Allows(this.GameEvent).Returns(true);

        var actual = this.Target.Add(this.GameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Add_RefereeDoesNotAllow_ReturnsNotAllowedResult()
    {
        this.GameEventHandler.CanHandle(this.GameEvent).Returns(true);
        this.GetDependency<IReferee>().Allows(this.GameEvent).Returns(false);

        var actual = this.Target.Add(this.GameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventStatus.NotAllowed, actual.Status);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_NoHandlersThatCanHandle_ThrowsException()
    {
        this.GameEventHandler.CanHandle(this.GameEvent).Returns(false);
        this.Target.Add(this.GameEvent);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_MultipleHandlersThatCanHandle_ThrowsException()
    {
        this.GameEventHandler.CanHandle(this.GameEvent).Returns(true);
        var secondEventHandler = Substitute.For<IGameEventHandler>();
        secondEventHandler.CanHandle(this.GameEvent).Returns(true);

        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler, secondEventHandler });
        this.Target.Add(this.GameEvent);
    }

    #endregion
}