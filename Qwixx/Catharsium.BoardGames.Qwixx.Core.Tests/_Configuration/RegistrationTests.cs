using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Interfaces.State.Models;
using Catharsium.BoardGames.Qwixx.Core._Configuration;
using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Core.Events.Models.Status;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Qwixx.Core.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddQwixxCore_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddQwixxCore(configuration);
        serviceCollection.ReceivedRegistration<Settings>();

        serviceCollection.ReceivedRegistration<IGameEventManager>();
        serviceCollection.ReceivedRegistration<IReferee, Referee>();
        serviceCollection.ReceivedRegistration<GameState, QwixxGame>();

        serviceCollection.ReceivedRegistration<IGameEventHandler, CrossCellEventHandler>();
    }


    [TestMethod]
    public void AddQwixxCore_RegistersProjects()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddQwixxCore(configuration);

        serviceCollection.ReceivedRegistration<IGameEventManager>();
    }
}