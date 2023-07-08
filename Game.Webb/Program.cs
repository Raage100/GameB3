using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Game.Webb;
using Game.Webb.Services;
using Game.Webb.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7134") });
builder.Services.AddScoped<IStateContainerService, StateContainerService>();

builder.Services.AddScoped<IGameService, GameService>();  
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ISportService, SportService>();
builder.Services.AddScoped<IScoreService,ScoreService >();


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();