using Game.Contracts.Sports.Request;
using Game.Contracts.Sports.Response;

namespace Game.Webb.Services
{
    public interface ISportService
    {
        Task<CreateSportResponse> CreateSport(CreateSportRequest createSportRequest);


        Task<List<GetSportsReponse>> GetSportsInGame(int gameId);

        Task<DeleteSportResponse> DeleteSport(int sportId);
    }
}
