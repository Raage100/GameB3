using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Queries
{
    public class GetPlayersInGameQuery : IRequest<ErrorOr<GetPlayersInGameResult>>
    {
        public int Id { get; set; }


        public GetPlayersInGameQuery(int id)
        {
            Id = id;
            
        }
    }
}
