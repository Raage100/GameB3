﻿using Game.Contracts.Players.Response;
using Game.Contracts.Scores.Request;
using Game.Contracts.Sports.Response;

namespace Game.Webb.State
{
    public interface IStateContainerService
    {
        event Action OnChange;
        public int GameId { get; set; }
        public string? GameName { get; set; }

        void SetGameId(int id);
        void NotifyStateChanged();
        int GetGameId();
        void setGameName(string name);

        List<CreateSportResponse> Sports { get; set; }
        List<CreatePlayerResponse> Players { get; set; }

        List<CreateScoreRequest> ScoresEntires { get; set; }




        void SportAdded(List<GetSportsReponse> sports);
        void PlayerAdded(List<CreatePlayerResponse> players);

       



    }
}
