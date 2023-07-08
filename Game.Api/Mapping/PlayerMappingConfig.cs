using Game.Application.Players.Commands.CreatePlayer;
using Game.Contracts.Players.Request;
using Game.Contracts.Players.Response;
using Mapster;

namespace Game.Api.Mapping
{
    public class PlayerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePlayerRequest, CreatePlayerCommand>();

            config.NewConfig<CreatePlayerResult, CreatePlayerResponse>();

        }
    }
}
