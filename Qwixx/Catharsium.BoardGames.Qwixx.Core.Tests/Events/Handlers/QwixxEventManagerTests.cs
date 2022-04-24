using Catharsium.BoardGames.Core.Interfaces.Events.Enums;
using Catharsium.BoardGames.Core.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Core.Interfaces.Events.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events.Handlers;

[TestClass]
public class QwixxEventManagerTests : TestFixture<Core.Events.Handlers.QwixxEventManager>
{
    #region Fixture

    private GameEvent GameEvent { get; set; }
    private IGameEventHandler GameEventHandler { get; set; }


    [TestInitialize]
    public void Initialize()
    {
        this.GameEvent = new GameEvent(GameEventType.CrossSquare, 123);
        this.GameEventHandler = Substitute.For<IGameEventHandler>();
        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler });
    }

    #endregion

    #region Add

    [TestMethod]
    public void Add_SingleHandlerThatCanHandle_ReturnsHandlerResult()
    {
        this.GameEventHandler.CanHandle(this.GameEvent.Type).Returns(true);
        var expected = new GameEventResult(GameEventResultType.Success, "My message");
        this.GameEventHandler.Handle(this.GameEvent).Returns(expected);
        this.GetDependency<IReferee>().Allows(this.GameEvent).Returns(true);

        var actual = this.Target.Add(this.GameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Add_RefereeDoesNotAllow_ReturnsNotAllowedResult()
    {
        this.GameEventHandler.CanHandle(this.GameEvent.Type).Returns(true);
        this.GetDependency<IReferee>().Allows(this.GameEvent).Returns(false);

        var actual = this.Target.Add(this.GameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(GameEventResultType.NotAllowed, actual.ResultType);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_NoHandlersThatCanHandle_ThrowsException()
    {
        var gameEvent = new GameEvent(GameEventType.CrossSquare, this.GameEvent.Player);
        this.GameEventHandler.CanHandle(gameEvent.Type).Returns(false);
        this.Target.Add(gameEvent);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_MultipleHandlersThatCanHandle_ThrowsException()
    {
        var gameEvent = new GameEvent(GameEventType.CrossSquare, this.GameEvent.Player);
        this.GameEventHandler.CanHandle(gameEvent.Type).Returns(true);

        var secondEventHandler = Substitute.For<IGameEventHandler>();
        secondEventHandler.CanHandle(gameEvent.Type).Returns(true);

        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler, secondEventHandler });
        this.Target.Add(gameEvent);
    }

    #endregion
}