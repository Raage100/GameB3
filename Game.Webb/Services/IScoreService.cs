using Game.Contracts.Scores.Request;
using Game.Contracts.Scores.Response;

namespace Game.Webb.Services
{
    public interface IScoreService
    {
        Task<CreateScoreResponse> AddScores(List<CreateScoreRequest> scores);
    }
}
