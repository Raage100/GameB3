using ErrorOr;
using Game.Application.Common.Interfaces.Persistence;
using Game.Domain.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Queries.GetSportsInGame
{
    public class GetSportsInGameQueryHandler : IRequestHandler<GetSportsInGameQuery, ErrorOr<GetSportsInGameResult>>
    {
        private readonly IGameDbContext _gameDbContext;

        public GetSportsInGameQueryHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<GetSportsInGameResult>> Handle(GetSportsInGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameDbContext.Gamees.FindAsync(request.Id);
            if (game == null)
            {
                return Errors.Gamee.GameDoesNotExist();
            }
            var sports = await _gameDbContext.Sports
                .Where(s => s.GameeId == request.Id).ToListAsync(cancellationToken);

            return new GetSportsInGameResult(sports);
        }
    }
}
