using Blazorise;
using Game.Contracts.Players.Request;
using Game.Contracts.Sports.Request;
using Game.Webb.Models;
using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components;

namespace Game.Webb.Pages
{
    public class TheGameBase : ComponentBase
    {
        public bool ShowAlert = false;

        public string Message { get; set; }
        [Inject]
        public NavigationManager? _navigationManager { get; set; }

        [Inject]
        public IStateContainerService? _stateContainerService { get; set; }
        [Inject]
        public IGameService? _gameService { get; set; }
        [Inject]
        public ISportService? _sportService { get; set; }

        [Inject]
        public IPlayerService? _playerService { get; set; }
        public CreateSportModel CreateSportModel { get; set; } = new();
        public CreatePlayerModel CreatePlayerModel { get; set; } = new();


        public Validations? validations;

        public int Gameid { get; set; }

        public async Task HandleAddingSport()
        {
           
                Console.WriteLine("Submit");
                Console.WriteLine(CreateSportModel.Name);

                int GameId = _stateContainerService.GetGameId();

                //check so that sports are are maximum 4 

                if(_stateContainerService.Sports.Count >= 4)
            {
                    ShowAlert = true;
                    Message = "You can only have 4 sports";
                    return;
                }
            




                var id = await _sportService?.CreateSport(new CreateSportRequest(CreateSportModel.Name, GameId));
                var sports = await _sportService.GetSportsInGame(GameId);

            _stateContainerService.SportAdded(sports);


        }

         public async Task HandleRemovingSport(int sportId)
        {

            int GameId = _stateContainerService.GetGameId();
            await _sportService.DeleteSport(sportId);
            var sports = await _sportService.GetSportsInGame(GameId);
            _stateContainerService.SportAdded(sports);
        }

        public async Task HandleRemovingPlayer(int playerId)
        {

            int GameId = _stateContainerService.GetGameId();
            await _playerService.DeletePlayer(playerId);
            var players = await _playerService.GetPlayersInGame(GameId);
            _stateContainerService.PlayerAdded(players);
        }
        

        public async Task HandleAddingPlayer()
        {
                int GameId = _stateContainerService.GetGameId();

                var id = await _playerService.CreatePlayer(new CreatePlayerRequest(CreatePlayerModel.Name, GameId));

                var players = await _playerService.GetPlayersInGame(GameId);
                Console.WriteLine(players);
                _stateContainerService.PlayerAdded(players);


        }


        public void CloseAlert()
        {
            ShowAlert = false;
        }   

        public void HandleStartGame()
        {
            _navigationManager?.NavigateTo("/StartGame");
        }





    }
}
