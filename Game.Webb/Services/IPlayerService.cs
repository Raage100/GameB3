using Game.Contracts.Players.Request;
using Game.Contracts.Players.Response;

namespace Game.Webb.Services
{
    public interface IPlayerService
    {
        Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest createPlayerRequest);

    }
}
