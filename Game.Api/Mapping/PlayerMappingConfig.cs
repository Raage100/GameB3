using Game.Application.Players.Commands.CreatePlayer;
using Game.Application.Players.Commands.DeletePlayer;
using Game.Application.Players.Queries;
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
            config.NewConfig<DeletePlayerResult, DeletePlayerResponse>();
            config.NewConfig<GetPlayersInGameResult, List<GetPlayersInGameResponse>>()
                .Map(dest => dest, src => src.PLayers);


        }
    }
}
