using Catharsium.BoardGames.Qwixx.Core._Configuration;
using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Core.Status;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Status.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.CodingTools.Tests._Configuration;

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

        serviceCollection.ReceivedRegistration<IEventManager, EventManager>();
        serviceCollection.ReceivedRegistration<IReferee, Referee>();
        serviceCollection.ReceivedRegistration<IGame, Game>();

        serviceCollection.ReceivedRegistration<IGameEventHandler, CrossCellEventHandler>();
    }
}