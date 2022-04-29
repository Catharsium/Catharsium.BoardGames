using Catharsium.BoardGames.Core._Configuration;
using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Core.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddBoardGamesCore_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddBoardGamesCore(configuration);
        serviceCollection.ReceivedRegistration<Settings>();

        serviceCollection.ReceivedRegistration<IGameEventManager, GameEventManager>();
    }
}