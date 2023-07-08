using Game.Application.Sports.Commands.CreateSport;
using Game.Application.Sports.Queries.GetSportsInGame;
using Game.Contracts.Sports.Request;
using Game.Contracts.Sports.Response;
using Mapster;

namespace Game.Api.Mapping
{
    public class SportMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<List<GetSportsInGameResult>, List<GetSportsReponse>>();

            config.NewConfig<CreateSportRequest, CreateSportCommand>();
            config.NewConfig<CreateSportResult, CreateSportResponse>();
        }
    }
}
