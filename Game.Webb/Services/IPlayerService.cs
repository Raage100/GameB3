using Game.Contracts.Players.Request;
using Game.Contracts.Players.Response;
using Game.Contracts.Sports.Response;

namespace Game.Webb.Services
{
    public interface IPlayerService
    {
        Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest createPlayerRequest);
        Task<DeletePlayerResponse> DeletePlayer(int playerId);

        Task<List<GetPlayersInGameResponse>> GetPlayersInGame(int gameId);
    }
}
