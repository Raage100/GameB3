using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<ErrorOr<CreatePlayerResult>>
    {
        public string Name { get; set; }
        public int GameId { get; set; }

        public CreatePlayerCommand(string name, int gameId)
        {
            Name = name;
            GameId = gameId;
        }
    }
}
