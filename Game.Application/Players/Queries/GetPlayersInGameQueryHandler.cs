using ErrorOr;
using Game.Application.Common.Interfaces.Persistence;
using MediatR;
using Game.Domain.Errors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Queries
{
    public class GetPlayersInGameQueryHandler : IRequestHandler<GetPlayersInGameQuery, ErrorOr<GetPlayersInGameResult>>
    {

        private readonly IGameDbContext _dbContext;

        public GetPlayersInGameQueryHandler(IGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ErrorOr<GetPlayersInGameResult>> Handle(GetPlayersInGameQuery request, CancellationToken cancellationToken)
        {

            var game = await _dbContext.Gamees.FindAsync(request.Id);
            if (game == null)
            {
                return Errors.Gamee.GameDoesNotExist();
            }
          
            var Players = await _dbContext.Players
               .Where(s => s.GameeId == request.Id).ToListAsync(cancellationToken);

            return new GetPlayersInGameResult(Players);

        }
    }
}
