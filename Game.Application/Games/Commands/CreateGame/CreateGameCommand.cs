using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<ErrorOr<CreateGameResult>>
    {
        public string Name { get; set; }

        public CreateGameCommand(string name)
        {
            Name = name;
        }
    }
}
