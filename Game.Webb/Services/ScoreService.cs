using Game.Contracts.Scores.Request;
using Game.Contracts.Scores.Response;
using System.Net.Http.Json;

namespace Game.Webb.Services
{
    public class ScoreService : IScoreService
    {
        private readonly HttpClient _httpClient;

        public ScoreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CreateScoreResponse> AddScores(List<CreateScoreRequest> scores)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Score/CreateScore", scores);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CreateScoreResponse>();

                return result;
            }
            else
            {
                throw new Exception("Scores could not be added");
            }
            
        }
    }
}
