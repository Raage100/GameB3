using Blazorise;
using Game.Contracts.Games.Request;
using Game.Webb.Models;
using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Game.Webb.Pages
{
    public class CreateGameBase : ComponentBase, IDisposable
    {

        protected CreateGameModel createGameModel { get; set; } = new();
        [Inject]
        NavigationManager? _navigationManager { get; set; }



        [Inject]
        public IGameService? _gameService { get; set; }
        [Inject]
      
        public IStateContainerService? _stateContainerService { get; set; }

        protected override void OnInitialized()
        {

            var game = _stateContainerService.GetGameId();
            if (game != 0)
            {
                _navigationManager?.NavigateTo("/Game");
            }
            else
            {
                _navigationManager?.NavigateTo("/CreateGame");
            }




            _stateContainerService.OnChange += StateHasChanged;
        }
        public void Dispose()
        {
            _stateContainerService.OnChange -= StateHasChanged;
        }


        public Validations? validations;

       protected async Task Submit()
        {
            if (await validations.ValidateAll())
            {
                var response = await _gameService.CreateGame(new CreateGameRequest(createGameModel.Name));
               
                _stateContainerService.SetGameId(response.Id);
               _stateContainerService.setGameName(createGameModel?.Name);


                if (response.Id != 0)
                {
                    _navigationManager.NavigateTo("/Game");
                }
                else
                {
                    _navigationManager.NavigateTo("/CreateGame");
                }

            }
        }


    }
}
