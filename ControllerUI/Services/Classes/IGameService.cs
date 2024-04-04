using ControllerUI.Entities;

namespace ControllerUI.Services.Classes
{
    public interface IGameService
    {
        Task<List<GameEntity>> GetAllGamesAsync();
    }
}