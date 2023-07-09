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

namespace Game.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, ErrorOr<CreatePlayerResult>>
    {
        private readonly IGameDbContext _gameDbContext;

        public CreatePlayerCommandHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<CreatePlayerResult>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {

            var game = await _gameDbContext.Gamees.Include(g => g.Players).FirstOrDefaultAsync(g => g.GameeId == request.GameId);

            if (game == null)
            {
                return Errors.Gamee.GameDoesNotExist();

            }

            var player = game.Players.FirstOrDefault(p => p.Name == request.Name);
            if (player != null)
            {
                return Errors.Player.PlayerAlreadyExists();
            }

            var newPlayer = new Player
            {
                Name = request.Name,
                GameeId = request.GameId
            };

            _gameDbContext.Players.Add(newPlayer);
            var result = await _gameDbContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                return new CreatePlayerResult(newPlayer.PlayerId, newPlayer.Name, newPlayer.GameeId);
            }
            else
            {
                return Errors.Player.PlayerCouldNotBeCreated();
            }

        }
    }

}

