namespace Catharsium.BoardGames.Interfaces.State.Interfaces;

public interface IGameManager
{
    bool CrossCell(int player, int row, int column);
}