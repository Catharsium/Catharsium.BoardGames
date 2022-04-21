using Catharsium.BoardGames.Qwixx.Core.Events;
using Catharsium.BoardGames.Qwixx.Core.Events.Handlers;
using Catharsium.BoardGames.Qwixx.Core.Status;
using Catharsium.BoardGames.Qwixx.Interfaces.Events.Interfaces;
using Catharsium.BoardGames.Qwixx.Interfaces.Status.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.BoardGames.Qwixx.Core._Configuration;

public static class Registration
{
    public static IServiceCollection AddQwixxCore(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.Load<Settings>();
        services.AddSingleton<Settings, Settings>(provider => settings);

        services.AddSingleton<IEventManager, EventManager>();
        services.AddSingleton<IReferee, Referee>();
        services.AddSingleton<IGame, Game>();

        services.AddScoped<IGameEventHandler, CrossCellEventHandler>();

        return services;
    }
}