using Catharsium.BoardGames.Mahjong.Core._Configuration;
using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.BoardGames.Mahjong.Core.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddMahjongCore_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var configuration = Substitute.For<IConfiguration>();

        serviceCollection.AddMahjongCore(configuration);
        serviceCollection.ReceivedRegistration<IStoneGroupFactory, StoneGroupFactory>();
        serviceCollection.ReceivedRegistration<IStoneTypeFilterFactory, StoneTypeFilterFactory>();

        serviceCollection.ReceivedRegistration<IStandardMahjongFilter, StandardMahjongFilter>();
        serviceCollection.ReceivedRegistration<IChowGroupFilter, ChowGroupFilter>();
        serviceCollection.ReceivedRegistration<IKongGroupFilter, KongGroupFilter>();
        serviceCollection.ReceivedRegistration<IPungGroupFilter, PungGroupFilter>();
        serviceCollection.ReceivedRegistration<ITwinGroupFilter, TwinGroupFilter>();

        serviceCollection.ReceivedRegistration<IHighStoneFilter, HighStoneFilter>();
        serviceCollection.ReceivedRegistration<INormalStoneFilter, NormalStoneFilter>();
        serviceCollection.ReceivedRegistration<IHonorStoneFilter, HonorStoneFilter>();

        serviceCollection.ReceivedRegistration<IChowPointsCalculator, ChowPointsCalculator>();
        serviceCollection.ReceivedRegistration<IClosingPairPointsCalculator, ClosingPairPointsCalculator>();
        serviceCollection.ReceivedRegistration<ICompletionPointsCalculator, CompletionPointsCalculator>();
        serviceCollection.ReceivedRegistration<IFinishingPointsCalculator, FinishingPointsCalculator>();
        serviceCollection.ReceivedRegistration<IKongPointsCalculator, KongPointsCalculator>();
        serviceCollection.ReceivedRegistration<IPungPointsCalculator, PungPointsCalculator>();
        serviceCollection.ReceivedRegistration<ISeasonPointsCalculator, SeasonPointsCalculator>();

        serviceCollection.ReceivedRegistration<ICombinationMultipliersCalculator, CombinationMultipliersCalculator>();
        serviceCollection.ReceivedRegistration<IHandMultipliersCalculator, HandMultipliersCalculator>();
        serviceCollection.ReceivedRegistration<IPungMultipliersCalculator, PungMultipliersCalculator>();
        serviceCollection.ReceivedRegistration<IRequiemMultipliersCalculator, RequiemMultipliersCalculator>();
        serviceCollection.ReceivedRegistration<IScaryMultipliersCalculator, ScaryMultipliersCalculator>();
        serviceCollection.ReceivedRegistration<ISeasonMultipliersCalculator, SeasonMultipliersCalculator>();

        serviceCollection.ReceivedRegistration<IHandScoreCalculator, HandScoreCalculator>();
    }
}