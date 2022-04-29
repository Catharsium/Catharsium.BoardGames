using Catharsium.BoardGames.Interfaces.Events.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.BoardGames.Core._Configuration;

public static class Registration
{
    public static IServiceCollection AddBoardGamesCore(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.Load<Settings>();
        services.AddSingleton<Settings, Settings>(provider => settings);

        services.AddSingleton<IGameEventManager, GameEventManager>();

        return services;
    }
}