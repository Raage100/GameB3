using Game.Application.Games.Commands.CreateGame;
using Game.Contracts.Games.Request;
using Game.Contracts.Games.Response;
using Mapster;

namespace Game.Api.Mapping
{
    public class GameMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateGameRequest, CreateGameCommand>();
            config.NewConfig<CreateGameResult, CreateGameResponse>();
        }
    }
}
