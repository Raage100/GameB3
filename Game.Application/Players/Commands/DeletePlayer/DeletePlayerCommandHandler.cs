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

namespace Game.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, ErrorOr<DeletePlayerResult>>
    {

        private readonly IGameDbContext _gameDbContext;

        public DeletePlayerCommandHandler(IGameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }
        public async Task<ErrorOr<DeletePlayerResult>> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _gameDbContext.Players.FirstOrDefaultAsync(x => x.PlayerId == request.Id);
            if (player == null)
            {
                return Errors.Player.PlayerDoesNotExist();
            }
            else
            {
                _gameDbContext.Players.Remove(player);
                var result = await _gameDbContext.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return new DeletePlayerResult(player.PlayerId, true);
                }
                else
                {
                    return Errors.Player.PlayerCouldNotBeDeleted();
                }
            }
        }
    }
}
