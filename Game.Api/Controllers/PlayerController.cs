using ErrorOr;
using Game.Application.Players.Commands.CreatePlayer;
using Game.Application.Players.Commands.DeletePlayer;
using Game.Contracts.Players.Request;
using Game.Contracts.Players.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
  
    public class PlayerController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlayerController(IMediator mediator, IMapper mapper)
        {
                _mediator = mediator;
                _mapper = mapper;
        }


        [HttpPost]
        [Route(nameof(CreatePlayer))]
        public async Task<IActionResult> CreatePlayer(CreatePlayerRequest request)
        {
            var command = _mapper.Map<CreatePlayerCommand>(request);
            ErrorOr<CreatePlayerResult> Result = await _mediator.Send(command);

            return Result.Match(result => Ok(_mapper.Map<CreatePlayerResponse>(result)), error => Problem(error));
        }

        [HttpPost]
        [Route(nameof(DeletePlayer))]
        public async Task<IActionResult> DeletePlayer(int PlayerId)
        {
            var command = new DeletePlayerCommand(PlayerId);
            ErrorOr<DeletePlayerResult> Result = await _mediator.Send(command);

            return Result.Match(result => Ok(result), error => Problem(error));
        }

    }
}
