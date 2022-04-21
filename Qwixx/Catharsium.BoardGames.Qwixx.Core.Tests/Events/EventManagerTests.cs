using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Enums;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
namespace Catharsium.BoardGames.Qwixx.Core.Tests.Events;

[TestClass]
public class EventManagerTests : TestFixture<EventManager>
{
    #region Fixture

    private static readonly int Player = 1;

    private IGameEventHandler GameEventHandler { get; set; }


    [TestInitialize]
    public void Initialize()
    {
        this.GameEventHandler = Substitute.For<IGameEventHandler>();
        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler });
    }

    #endregion

    #region Add

    [TestMethod]
    public void Add_SingleHandlerThatCanHandle_ReturnsHandlerResult()
    {
        var gameEvent = new GameEvent(EventType.CrossSquare, Player);
        this.GameEventHandler.CanHandle(gameEvent.Type).Returns(true);
        var expected = new EventResult(EventResultType.Success, "My message");
        this.GameEventHandler.Handle(gameEvent).Returns(expected);

        var actual = this.Target.Add(gameEvent);
        Assert.IsNotNull(actual);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_NoHandlersThatCanHandle_ThrowsException()
    {
        var gameEvent = new GameEvent(EventType.CrossSquare, Player);
        this.GameEventHandler.CanHandle(gameEvent.Type).Returns(false);
        this.Target.Add(gameEvent);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Add_MultipleHandlersThatCanHandle_ThrowsException()
    {
        var gameEvent = new GameEvent(EventType.CrossSquare, Player);
        this.GameEventHandler.CanHandle(gameEvent.Type).Returns(true);

        var secondEventHandler = Substitute.For<IGameEventHandler>();
        secondEventHandler.CanHandle(gameEvent.Type).Returns(true);

        this.SetDependency<IEnumerable<IGameEventHandler>>(new[] { this.GameEventHandler, secondEventHandler });

        this.Target.Add(gameEvent);
    }

    #endregion
}