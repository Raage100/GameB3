using ErrorOr;
using Game.Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Game.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Domain.Entites;

namespace Game.Application.Sports.Commands.CreateSport
{
    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, ErrorOr<CreateSportResult>>
    {

        private readonly IGameDbContext _gameDbContext;

        public CreateSportCommandHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<CreateSportResult>> Handle(CreateSportCommand request, CancellationToken cancellationToken)
        {
            //check if Game exists in the database
            var game = await _gameDbContext.Gamees.FirstOrDefaultAsync(g => g.GameeId == request.GameId);
            if(game == null)
            {
               return Errors.Gamee.GameDoesNotExist();
            }

            //check if Sport already exists in the database in the same Game
            var sport = await _gameDbContext.Sports.FirstOrDefaultAsync(s => s.Name == request.Name && s.GameeId == request.GameId);
            if(sport != null)
            {
                return Errors.Sport.SportAlreadyExists();
            }
            
            sport = new Sport
            {
                Name = request.Name,
                GameeId = request.GameId
            };

           await _gameDbContext.Sports.AddAsync(sport);
           var result = await _gameDbContext.SaveChangesAsync(cancellationToken);
            //check if Sport was successfully added to the database
            if(result > 0)
            {
                return new CreateSportResult(sport);
            }
            else
            {
                return Errors.Sport.SportCouldNotBeCreated();
            }
          
      

           
        }
    }
}
