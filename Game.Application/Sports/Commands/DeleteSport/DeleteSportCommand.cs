using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.DeleteSport
{
    public class DeleteSportCommand : IRequest<ErrorOr<DeleteSportResult>>
    {
        public int SportId { get; set; }

        public DeleteSportCommand(int sportId)
        {
            SportId = sportId;
            
        }

    }
}
