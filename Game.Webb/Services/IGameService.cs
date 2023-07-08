
using Game.Contracts.Games.Request;
using Game.Contracts.Games.Response;

namespace Game.Webb.Services
{
    public interface IGameService
    {
        Task<CreateGameResponse> CreateGame(CreateGameRequest createGameRequest);
    }
}
