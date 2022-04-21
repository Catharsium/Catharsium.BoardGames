using Catharsium.BoardGames.Mahjong.Core._Configuration;
using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Stones;
using Catharsium.BoardGames.Mahjong.Interface.Interfaces.Factories;
using Catharsium.BoardGames.Mahjong.Interfaces.Interfaces.Scoring;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
namespace Catharsium.BoardGames.Mahjong.UI.Basic;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, false);
        var configuration = builder.Build();

        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddMahjongCore(configuration)
            .AddConsoleIoUtilities(configuration)
            .BuildServiceProvider();
        var console = serviceProvider.GetService<IConsole>();
        var stoneGroupFactory = serviceProvider.GetService<IStoneGroupFactory>();
        var handScoreCalculator = serviceProvider.GetService<IHandScoreCalculator>();

        var hand = new Hand();
        hand.Groups.Add(stoneGroupFactory.CreatePung<BambooStone>(1, true));
        hand.Groups.Add(stoneGroupFactory.CreatePung<WindStone>(1, true));
        hand.Groups.Add(stoneGroupFactory.CreatePung<BambooStone>(3, true));
        hand.Groups.Add(stoneGroupFactory.CreatePung<SignStone>(4, true));
        hand.Stones.Add(new DragonStone(1));

        var scoreCard = handScoreCalculator.Calculate(hand);

        foreach (var (category, value) in scoreCard.Categories) {
            console.WriteLine($"{category}: {value}");
        }

        console.WriteLine();
        console.WriteLine($"Total: {scoreCard.Total}");
    }
}