using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Commands.CreateSport
{
    public class CreateSportCommand : IRequest<ErrorOr<CreateSportResult>>
    {
        public string Name { get; set; }
        public int GameId { get; set; }


        public CreateSportCommand(string name, int gameId)
        {
           Name = name;
           GameId = gameId;
        }
    }
}
