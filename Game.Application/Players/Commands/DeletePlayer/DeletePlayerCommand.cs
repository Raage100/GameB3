using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommand : IRequest<ErrorOr<DeletePlayerResult>>
    {
        public int Id { get; set; }

        public DeletePlayerCommand(int id)
        {
            Id = id;
        }

    }
}
