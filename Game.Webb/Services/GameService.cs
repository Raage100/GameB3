using Game.Contracts.Games.Request;
using Game.Contracts.Games.Response;
using Game.Webb.State;
using System.Net.Http.Json;

namespace Game.Webb.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateContainerService _stateContainerService;

        public GameService(HttpClient httpClient, IStateContainerService stateContainerService)
        {
            _httpClient = httpClient;
            _stateContainerService = stateContainerService;
        }

        public async Task<CreateGameResponse> CreateGame(CreateGameRequest createGameRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/game/CreateGame", createGameRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CreateGameResponse>();
                _stateContainerService.SetGameId(result.Id);
                return result;
            }
            else
            {
                throw new Exception("Game could not be created");
            }
        }
    }
}
