using ErrorOr;
using Game.Application.Sports.Commands.CreateSport;
using Game.Application.Sports.Commands.DeleteSport;
using Game.Application.Sports.Queries.GetSportsInGame;
using Game.Contracts.Sports.Request;
using Game.Contracts.Sports.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]

    public class SportsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        

       public SportsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        [Route(nameof(GetSportsInGame))]

        public async Task<ActionResult<GetSportsReponse>> GetSportsInGame(int GameId)
        {

            var query = new GetSportsInGameQuery(GameId);

            ErrorOr<GetSportsInGameResult> Result = await _mediator.Send(query);

            return (ActionResult)Result.Match(Result => Ok(_mapper.Map<List<GetSportsReponse>>(Result.Sports)), Error => Problem(Error));

            
          
        }

        [HttpPost]

        [Route(nameof(CreateSport))]
        public async Task<IActionResult> CreateSport(CreateSportRequest request)
        {
            var command = _mapper.Map<CreateSportCommand>(request);
            ErrorOr<CreateSportResult> Result = await _mediator.Send(command);

            return Result.Match(result => Ok(_mapper.Map<CreateSportResponse>(result.Sport)), error => Problem(error));
        }

        [HttpPost]
        [Route(nameof(DeleteSport))]
        public async Task<IActionResult> DeleteSport (DeleteSportRequest deleteSportRequest)
        {
            var command = new DeleteSportCommand(deleteSportRequest.SportId);
            ErrorOr<DeleteSportResult> Result = await _mediator.Send(command);

            return Result.Match(result => Ok(result), error => Problem(error));
        }

    }
}
