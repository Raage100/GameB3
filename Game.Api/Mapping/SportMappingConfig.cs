using Game.Application.Sports.Queries;
using Game.Contracts.Sports;
using Mapster;

namespace Game.Api.Mapping
{
    public class SportMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<List<GetSportsInGameResult>, List<GetSportsReponse>>();
        }
    }
}
