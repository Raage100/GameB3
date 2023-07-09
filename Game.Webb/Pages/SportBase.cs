using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components;


namespace Game.Webb.Pages
{
    public class SportBase : ComponentBase, IDisposable
    {
        [Inject]
        public IGameService _gameService { get; set; }
        [Inject]
        public ISportService _sportService { get; set; }

        [Inject]
        public IStateContainerService _stateContainerService { get; set; }

        public void Dispose()
        {
            _stateContainerService.OnChange -= StateHasChanged;
        }

        protected override void OnInitialized()
        {
            _stateContainerService.OnChange += StateHasChanged;
        }


        public async Task HandleRemoveSport(int sportId)
        {
        


           var response = await _sportService.DeleteSport(sportId);
            
            if(response.Deleted == true)
            {
                _stateContainerService.RemoveSport(sportId);
            }
            else
            {
               return;
            }
           
            
        }
    }
}
