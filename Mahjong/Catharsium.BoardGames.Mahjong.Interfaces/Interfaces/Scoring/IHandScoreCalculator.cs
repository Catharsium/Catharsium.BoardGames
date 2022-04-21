using Catharsium.BoardGames.Mahjong.Interface.Entities;
using Catharsium.BoardGames.Mahjong.Interface.Entities.Scoring;

namespace Catharsium.BoardGames.Mahjong.Interfaces.Interfaces.Scoring;

public interface IHandScoreCalculator
{
    ScoreCard Calculate(Hand hand);
}