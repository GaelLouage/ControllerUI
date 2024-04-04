using ControllerUI.Entities;

namespace ControllerUI.Services.Interfaces
{
    public interface IGameService
    {
        Task<List<GameEntity>> GetAllGamesAsync();
    }
}