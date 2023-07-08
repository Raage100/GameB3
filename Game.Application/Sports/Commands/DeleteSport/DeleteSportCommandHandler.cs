using ErrorOr;
using Game.Application.Common.Interfaces.Persistence;
using MediatR;
using Game.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Game.Application.Sports.Commands.DeleteSport
{
    public class DeleteSportCommandHandler : IRequestHandler<DeleteSportCommand, ErrorOr<DeleteSportResult>>
    {
        private readonly IGameDbContext _dbContext;

        public DeleteSportCommandHandler(IGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<DeleteSportResult>> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
        {

            var sport = await _dbContext.Sports.FirstOrDefaultAsync(x => x.SportId == request.SportId, cancellationToken);

            if (sport == null)
            {
                return Errors.Sport.SportDoesNotExist();
            }

            _dbContext.Sports.Remove(sport);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                return new DeleteSportResult(sport.SportId, true);
            }
            else
            {
                return Errors.Sport.SportCouldNotBeDeleted();
            }
        }
    }
}
