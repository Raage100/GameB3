using Game.Contracts.Sports.Request;
using Game.Webb.Models;
using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components;

namespace Game.Webb.Pages
{
    public class GameBase : ComponentBase
    {

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

        public int Gameid { get; set; }

        public async Task HandleAddingSport()
        {
            Console.WriteLine("Submit");
            Console.WriteLine(CreateSportModel.Name);

            int GameId = _stateContainerService.GetGameId();

            var id = await _sportService?.CreateSport(new CreateSportRequest(CreateSportModel.Name, GameId));
            var sports = await _sportService.GetSportsInGame(GameId);

            _stateContainerService.SportAdded(sports);


            

        }

        public async Task HandleAddingPlayer()
        {


            int GameId = _stateContainerService.GetGameId();

            var id = await PlayerService?.CreatePlayer(PlayerModel.Name, GameId);

            var players = await PlayerService.GetPlayersInGame(StateContainerService.GameId);

            StateContainerService.PlayerAdded(players);



        }




    }
}
