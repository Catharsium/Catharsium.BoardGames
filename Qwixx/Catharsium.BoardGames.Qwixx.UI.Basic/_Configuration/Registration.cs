using Catharsium.BoardGames.Qwixx.Core._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.BoardGames.Qwixx._Configuration;

public static class Registration
{
    public static IServiceCollection AddQwixx(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.Load<Settings>();
        services.AddSingleton<Settings, Settings>(provider => settings);

        services.AddConsoleIoUtilities(config);

        services.AddQwixxCore(config);

        return services;
    }
}