using ErrorOr;
using Game.Application.Sports.Queries;
using Game.Contracts.Sports;
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

        public async Task<ActionResult<GetSportsReponse>> GetSportsInGame(int id)
        {

            var query = new GetSportsInGameQuery(id);

            ErrorOr<GetSportsInGameResult> Result = await _mediator.Send(query);

            return (ActionResult)Result.Match(Result => Ok(_mapper.Map<GetSportsReponse>(Result)), Error => Problem(Error));

            
          
        }
    }
}
