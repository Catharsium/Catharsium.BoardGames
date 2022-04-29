using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Scoring;

namespace Catharsium.BoardGames.Mahjong.Interface.Interfaces.Scoring;

public interface IHandScoreCalculator
{
    ScoreCard Calculate(Hand hand);
}