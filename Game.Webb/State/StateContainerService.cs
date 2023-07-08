using Game.Contracts.Players.Response;
using Game.Contracts.Scores.Request;
using Game.Contracts.Sports.Response;

namespace Game.Webb.State
{
    public class StateContainerService : IStateContainerService
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public List<CreateSportResponse> Sports { get; set; } = new();
        public List<CreatePlayerResponse> Players { get; set; } = new();
        public List<CreateScoreRequest> ScoresEntires { get; set; } = new();

        public event Action OnChange;

        public int GetGameId()
        {
            return GameId;
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }

        public void PlayerAdded(List<CreatePlayerResponse> players)
        {
            Players = players;
            NotifyStateChanged();
        }

        public void SetGameId(int id)
        {
            GameId = id;
            NotifyStateChanged();
        }

        public void setGameName(string name)
        {
            GameName = name;
        }

        public void SportAdded(List<CreateSportResponse> sports)
        {
            Sports = sports;
            NotifyStateChanged();
        }
    }
}
