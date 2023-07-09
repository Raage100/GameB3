using Game.Webb.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Game.Webb.Pages
{
    public class EndGameBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStateContainerService _stateContainerService { get; set; }


        [Inject]
        public NavigationManager _navigationManager { get; set; }

        private string _previousUri;




        protected override void OnInitialized()
        {

            _previousUri = _navigationManager.Uri;
            _navigationManager.LocationChanged += OnLocationChanged;

        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= OnLocationChanged;
        }



        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (_previousUri != _navigationManager.Uri)
            {
                _stateContainerService.playersScores.Clear();
                _stateContainerService.setGameName(string.Empty);
                _navigationManager.NavigateTo("/CreateGame", true);
            }
            _previousUri = _navigationManager.Uri;
        }
    }
}
