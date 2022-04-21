using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.UI.Basic._Configuration;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.UI.Basic.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddFinanceUiConsole_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddMahjongBasicUi(configuration);
        serviceCollection.ReceivedRegistration<IStoneGroupFactory>();
    }
}