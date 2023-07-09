using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components;

namespace Game.Webb.Pages
{
    public class PlayerBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStateContainerService _stateContainerService { get; set; }

        [Inject]
        public IPlayerService _playerService { get; set; }



        

        public void Dispose()
        {
            _stateContainerService.OnChange -= StateHasChanged;
        }

        protected override void OnInitialized()
        {
            _stateContainerService.OnChange += StateHasChanged;
        }



        public async Task HandleRemovePlayer(int playerId)
        {


            var response = await _playerService.DeletePlayer(playerId);
            

            if (response.Deleted == true)
            {
                _stateContainerService.RemovePlayer(playerId);
            }
            else
            {
                return;
            }


        }

    }
}
