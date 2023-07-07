using Game.Application.Games.Commands.CreateGame;
using Game.Contracts.Games.Request;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    public class GameController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
    

        public GameController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> CreateGame(CreateGameRequest request)
        {
            var command = _mapper.Map<CreateGameCommand>(request);
            var result = await _mediator.Send(command);
    
                                                         );
        }
    }
}
