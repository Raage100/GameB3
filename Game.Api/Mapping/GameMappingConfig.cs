using Game.Application.Games.Commands.CreateGame;
using Game.Contracts.Games.Request;
using Mapster;

namespace Game.Api.Mapping
{
    public class GameMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateGameRequest, CreateGameCommand>();
        }
    }
}
