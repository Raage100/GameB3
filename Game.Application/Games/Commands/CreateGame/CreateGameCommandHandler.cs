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

namespace Game.Application.Games.Commands.CreateGame
{
    internal class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, ErrorOr<CreateGameResult>>
    {
        private readonly IGameDbContext _gameDbContext;

        public CreateGameCommandHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<CreateGameResult>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
        {
            var game = new Gamee
            {
                Name = command.Name
            };


            _gameDbContext.Gamees.Add(game);

            var result = await _gameDbContext.SaveChangesAsync(cancellationToken);


            if (result > 0)
            {
                return new CreateGameResult(game.GameeId);
            }
            else
            {
                return Errors.Gamee.GameCouldNotBeCreated();
            }


        }
    }
}
