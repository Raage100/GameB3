using Game.Application.Scores.Commands.CreateScore;
using Game.Contracts.Scores.Request;
using Game.Contracts.Scores.Response;
using Mapster;

namespace Game.Api.Mapping
{
    public class ScoreMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<List<CreateScoreRequest>, CreateScoreCommand>()
                .Map(dest => dest.Scores, src => src);

            config.NewConfig<CreateScoreResult, CreateScoreResponse>();

        }
    }
}
