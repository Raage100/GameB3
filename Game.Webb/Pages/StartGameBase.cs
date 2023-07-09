using Game.Webb.Services;
using Game.Webb.State;
using Game.Contracts.Players.Response;
using Game.Contracts.Scores.Request;
using Game.Contracts.Sports.Response;
using Microsoft.AspNetCore.Components;
using Game.Webb.Models;
using Microsoft.AspNetCore.Components.Routing;

namespace Game.Webb.Pages
{
    public class StartGameBase : ComponentBase, IDisposable
    {

        private bool isGameEnded = false;
        public bool ShowAlert = false;

        public string Message { get; set; }
        [Inject]
        public NavigationManager? _navigationManager { get; set; }
        [Inject]
        public IScoreService? ScoreService { get; set; }


        [Inject]
        public IStateContainerService? _stateContainerService { get; set; }

        public List<GetSportsReponse> Sports { get; set; } = new();

        public List<GetPlayersInGameResponse> Players { get; set; } = new();


        public string SelectedSport { get; set; } = "none selected";
        public int SelectedSportId { get; set; } = 0;

        protected override void OnInitialized()
        {
            Sports = _stateContainerService?.Sports;
            Players = _stateContainerService?.Players;
            DisableBrowserBackNavigation();

        }


        private void DisableBrowserBackNavigation()
        {
            _navigationManager.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (!isGameEnded)
            {
                _navigationManager.NavigateTo("/StartGame");
            }
            else
            {
                _navigationManager.LocationChanged -= OnLocationChanged;
            }
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= OnLocationChanged;
        }


        public int GetPlayerScore(int playerId)
        {
            var scoreEntry = _stateContainerService?.ScoresEntires
                   .FirstOrDefault(se => se.SportId == SelectedSportId && se.PlayerId == playerId);

            if (scoreEntry != null)
            {
                return scoreEntry.Points;
            }
            else
            {
               
                scoreEntry = new CreateScoreRequest
                {
                    SportId = SelectedSportId,
                    PlayerId = playerId,
                    Points = 0
                };
                _stateContainerService?.ScoresEntires.Add(scoreEntry);

                return scoreEntry.Points;
            }

        }

        public void CloseAlert()
        {
            ShowAlert = false;
        }

        public void SetPlayerScore(int playerId, int score)
        {
            var scoreEntry = _stateContainerService?.ScoresEntires
                .FirstOrDefault(se => se.SportId == SelectedSportId && se.PlayerId == playerId);
            if (scoreEntry != null)
            {
                scoreEntry.Points = score;
            }
            else
            {
                _stateContainerService?.ScoresEntires.Add(new CreateScoreRequest
                {
                    PlayerId = playerId,
                    SportId = SelectedSportId,
                    Points = score
                });
            }
        }

        public void UpdatePlayerScore(int playerId, string input)
        {
            if (int.TryParse(input, out int score))
            {
                SetPlayerScore(playerId, score);
            }
            else if (input == string.Empty)
            {
                SetPlayerScore(playerId, 0);
            }
            else
            {
                // Invalid input value
                // You can handle this error condition as needed (e.g., show an error message)
                ShowAlert = true;
                Message = "Invalid input value. Please enter a valid number.";
            }
        }
        public void SelectedSportChanged(string value, int id)
        {
            SelectedSport = value;
            SelectedSportId = id;
            StateHasChanged();
        }


        public async Task SaveScores()
        {


            var CountOfPlayersAndGames = _stateContainerService?.Players.Count * _stateContainerService?.Sports.Count;



            if (_stateContainerService?.ScoresEntires.Count != CountOfPlayersAndGames)
            {
                ShowAlert = true;
                Message = "you have to enter points for every game ";
                return;
            }


            var allPoints = _stateContainerService?.ScoresEntires.Sum(x => x.Points);
            if (allPoints == 0)
            {
                ShowAlert = true;
                Message = "you have enter point for player";
                return;
            }


            if (_stateContainerService?.ScoresEntires != null)
            {
                var result = await ScoreService.AddScores(_stateContainerService.ScoresEntires);

                if (result.ScoresSaved == true)
                {
                
                    var players = _stateContainerService.Players;
                    var scores = _stateContainerService.ScoresEntires;
                    var sports = _stateContainerService.Sports;

                    var playersWithScores = new List<PlayerWithScore>();

                    foreach (var player in players)
                    {
                        var playerScore = scores.Where(x => x.PlayerId == player.PlayerId).Sum(x => x.Points);
                        playersWithScores.Add(new PlayerWithScore { PlayerId = player.PlayerId, PlayerName = player.Name, Score = playerScore });
                    }

                    var sortedPlayers = playersWithScores.OrderByDescending(x => x.Score).Take(3).ToList();
                



                    _stateContainerService.playersScores = sortedPlayers;


                    _stateContainerService?.ScoresEntires.Clear();
                    _stateContainerService?.Players.Clear();
                    _stateContainerService?.Sports.Clear();
                    _stateContainerService.SetGameId(0);

                    isGameEnded = true;
                    _navigationManager.NavigateTo("/EndGame");

                    Console.WriteLine("Scores saved successfully.");

                }

                else
                {
                    ShowAlert = true;
                    Message = "something went wrong";
                }


            }
            else
            {
                return;
            }




        }






    }
}
