using Game.Webb.State;
using Microsoft.AspNetCore.Components;

namespace Game.Webb.Pages
{
    public class PlayerBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStateContainerService _stateContainerService { get; set; }



        public void HandleRemoveSport(int playerId)
        {
            //sportService.RemoveSport(sportId);
            //StateContainerService.StateHasChanged();
        }

        public void Dispose()
        {
            _stateContainerService.OnChange -= StateHasChanged;
        }

        protected override void OnInitialized()
        {
            _stateContainerService.OnChange += StateHasChanged;
        }

    }
}
