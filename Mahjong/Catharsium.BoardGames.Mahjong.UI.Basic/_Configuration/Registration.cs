using Catharsium.BoardGames.Mahjong.Core._Configuration;
using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Catharsium.BoardGames.Mahjong.UI.Basic._Configuration;

public static class Registration
{
    public static IServiceCollection AddMahjongBasicUi(this IServiceCollection services, IConfiguration configuration)
    {
        var coreLogicConfiguration = configuration.Load<Settings>();
        services.AddSingleton<Settings, Settings>(provider => coreLogicConfiguration);

        services.AddMahjongCore(configuration);

        return services;
    }
}