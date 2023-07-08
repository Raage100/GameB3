using Game.Contracts.Games.Response;
using Game.Contracts.Sports.Request;
using Game.Contracts.Sports.Response;
using Game.Webb.State;
using System.Net.Http.Json;

namespace Game.Webb.Services
{
    public class SportService : ISportService
    {

        private readonly HttpClient _httpClient;
        private readonly IStateContainerService _stateContainerService;


        public SportService(HttpClient httpClient, IStateContainerService stateContainerService)
        {
            _httpClient = httpClient;
            _stateContainerService = stateContainerService;
        }
        public async Task<CreateSportResponse> CreateSport(CreateSportRequest createSportRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/sports/CreateSport", createSportRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CreateSportResponse>();

                return result;
            }
            else
            {
                throw new Exception("Game could not be created");
            }
        }

        public async Task<List<GetSportsReponse>> GetSportsInGame(int gameId)
        {
           var response = await _httpClient.GetAsync($"api/sports/GetSportsInGame?GameId={gameId}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetSportsReponse>>();

                return result;
            }
            else
            {
                throw new Exception("Sports could not be found");
            }
        }
    }
}
