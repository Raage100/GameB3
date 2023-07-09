using Game.Contracts.Players.Request;
using Game.Contracts.Players.Response;
using Game.Webb.State;
using System.Net.Http.Json;

namespace Game.Webb.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly HttpClient _httpClient;
        private readonly IStateContainerService _stateContainerService;

        public PlayerService(HttpClient httpClient, IStateContainerService stateContainerService)
        {
            _httpClient = httpClient;
            _stateContainerService = stateContainerService;
        }
        public async Task<CreatePlayerResponse> CreatePlayer(CreatePlayerRequest createPlayerRequest)
        {

            if (createPlayerRequest == null)
            {
                throw new Exception("Player could not be created");
            }
           

            var response = await _httpClient.PostAsJsonAsync("api/player/CreatePlayer", createPlayerRequest);
            if (response.IsSuccessStatusCode)
            {
                var createPlayerResponse = await response.Content.ReadFromJsonAsync<CreatePlayerResponse>();
                return createPlayerResponse;
            }
            else
            {
                throw new Exception($"Failed to create sport");
            }

        }

        public async Task<DeletePlayerResponse> DeletePlayer(int playerId)
        {
         


            var deletePlayerRequest = new DeletePlayerRequest(playerId);

            var response = await _httpClient.PostAsJsonAsync("api/player/DeletePlayer", deletePlayerRequest);
            if (response.IsSuccessStatusCode)
            {
                var deletePlayerResponse = await response.Content.ReadFromJsonAsync<DeletePlayerResponse>();
                return deletePlayerResponse;
            }
            else
            {
                throw new Exception($"Failed to delete player");
            }
        }

        public async Task<List<GetPlayersInGameResponse>> GetPlayersInGame(int gameId)
        {
           var  response = await _httpClient.GetAsync($"api/player/GetPlayersInGame?GameId={gameId}");
            if (response.IsSuccessStatusCode)
            {
                var getPlayersInGameResponse = await response.Content.ReadFromJsonAsync<List<GetPlayersInGameResponse>>();
                return getPlayersInGameResponse;
            }
            else
            {
                throw new Exception($"Failed to get players in game");
            }
        }
    }
}
