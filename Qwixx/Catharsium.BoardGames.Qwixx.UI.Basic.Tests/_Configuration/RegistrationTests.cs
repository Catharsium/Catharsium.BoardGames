using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.UI.Basic._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Qwixx.UI.Basic.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddCodingTools_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddQwixx(configuration);
        serviceCollection.ReceivedRegistration<Settings>();
    }


    [TestMethod]
    public void AddCodingTools_RegistersProjects()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddQwixx(configuration);
        serviceCollection.ReceivedRegistration<Settings>();

        serviceCollection.ReceivedRegistration<IGameEventManager>();
    }


    [TestMethod]
    public void AddCodingTools_RegistersPackages()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddQwixx(configuration);
        serviceCollection.ReceivedRegistration<Settings>();

        serviceCollection.ReceivedRegistration<IConsole>();
    }
}