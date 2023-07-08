using ErrorOr;
using Game.Application.Common.Interfaces.Persistence;
using Game.Domain.Entites;
using Game.Domain.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Scores.Commands.CreateScore
{
    public class CreateScoreCommandHandler : IRequestHandler<CreateScoreCommand, ErrorOr<CreateScoreResult>>
    {

        private readonly IGameDbContext _gameDbContext;

        public CreateScoreCommandHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<CreateScoreResult>> Handle(CreateScoreCommand request, CancellationToken cancellationToken)
        {
           foreach (var item in request.Scores)
            {
                var score = new Score
                {
          
                    PlayerId = item.PlayerId,
                    SportId = item.SportId,
                    Points = item.Points,
                };

                _gameDbContext.Scores.Add(score);
            }

            var result = await _gameDbContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                return  new CreateScoreResult( true);
            }
            else
            {
                return  Errors.Score.ScoreCouldNotBeCreated();
            }   

        }
    }
}
