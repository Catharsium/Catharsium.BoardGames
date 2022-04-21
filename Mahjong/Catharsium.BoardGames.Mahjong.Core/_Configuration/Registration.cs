using Catharsium.BoardGames.Mahjong.Core.Factories;
using Catharsium.BoardGames.Mahjong.Core.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Core.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Core.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Core.Scoring;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Core.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Hands;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.StoneGroups;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Filters.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Multipliers;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring.Points;
using Catharsium.BoardGames.Mahjong.Interfaces.Interfaces.Scoring;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.BoardGames.Mahjong.Core._Configuration;

public static class Registration
{
    public static IServiceCollection AddMahjongCore(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Load<Settings>();
        services.AddSingleton<Settings, Settings>(provider => settings);

        services.AddScoped<IStoneGroupFactory, StoneGroupFactory>();
        services.AddScoped<IStoneTypeFilterFactory, StoneTypeFilterFactory>();

        services.AddScoped<IStandardMahjongFilter, StandardMahjongFilter>();
        services.AddScoped<IChowGroupFilter, ChowGroupFilter>();
        services.AddScoped<IKongGroupFilter, KongGroupFilter>();
        services.AddScoped<IPungGroupFilter, PungGroupFilter>();
        services.AddScoped<ITwinGroupFilter, TwinGroupFilter>();
        services.AddScoped<IStoneTypeFilter, StoneTypeFilter<BambooStone>>();
        services.AddScoped<IStoneTypeFilter, StoneTypeFilter<WheelStone>>();
        services.AddScoped<IStoneTypeFilter, StoneTypeFilter<SignStone>>();
        services.AddScoped<IStoneTypeFilter, StoneTypeFilter<DragonStone>>();
        services.AddScoped<IStoneTypeFilter, StoneTypeFilter<WindStone>>();

        services.AddScoped<IHighStoneFilter, HighStoneFilter>();
        services.AddScoped<INormalStoneFilter, NormalStoneFilter>();
        services.AddScoped<IHonorStoneFilter, HonorStoneFilter>();

        services.AddScoped<IPointsCalculator, ChowPointsCalculator>();
        services.AddScoped<IPointsCalculator, ClosingPairPointsCalculator>();
        services.AddScoped<IPointsCalculator, KongPointsCalculator>();
        services.AddScoped<IPointsCalculator, PungPointsCalculator>();
        services.AddScoped<IPointsCalculator, SeasonPointsCalculator>();
        services.AddScoped<IChowPointsCalculator, ChowPointsCalculator>();
        services.AddScoped<IClosingPairPointsCalculator, ClosingPairPointsCalculator>();
        services.AddScoped<ICompletionPointsCalculator, CompletionPointsCalculator>();
        services.AddScoped<IFinishingPointsCalculator, FinishingPointsCalculator>();
        services.AddScoped<IKongPointsCalculator, KongPointsCalculator>();
        services.AddScoped<IPungPointsCalculator, PungPointsCalculator>();
        services.AddScoped<ISeasonPointsCalculator, SeasonPointsCalculator>();

        services.AddScoped<IMultipliersCalculator, CombinationMultipliersCalculator>();
        services.AddScoped<IMultipliersCalculator, HandMultipliersCalculator>();
        services.AddScoped<IMultipliersCalculator, PungMultipliersCalculator>();
        services.AddScoped<IMultipliersCalculator, RequiemMultipliersCalculator>();
        services.AddScoped<IMultipliersCalculator, ScaryMultipliersCalculator>();
        services.AddScoped<IMultipliersCalculator, SeasonMultipliersCalculator>();
        services.AddScoped<ICombinationMultipliersCalculator, CombinationMultipliersCalculator>();
        services.AddScoped<IHandMultipliersCalculator, HandMultipliersCalculator>();
        services.AddScoped<IPungMultipliersCalculator, PungMultipliersCalculator>();
        services.AddScoped<IRequiemMultipliersCalculator, RequiemMultipliersCalculator>();
        services.AddScoped<IScaryMultipliersCalculator, ScaryMultipliersCalculator>();
        services.AddScoped<ISeasonMultipliersCalculator, SeasonMultipliersCalculator>();

        services.AddScoped<IHandScoreCalculator, HandScoreCalculator>();

        return services;
    }
}