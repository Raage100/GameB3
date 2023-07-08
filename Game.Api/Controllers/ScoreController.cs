using ErrorOr;
using Game.Application.Scores.Commands.CreateScore;
using Game.Contracts.Scores.Request;
using Game.Contracts.Scores.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]

    public class ScoreController : ApiController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        

       public ScoreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]

        [Route(nameof(CreateScore))]
        public async Task<IActionResult> CreateScore(List<CreateScoreRequest> request)
        {
            var command = _mapper.Map<CreateScoreCommand>(request);
            ErrorOr<CreateScoreResult> Result = await _mediator.Send(command);

            return Result.Match(result => Ok(_mapper.Map<CreateScoreResponse>(result)), error => Problem(error));
        }
    }
}
