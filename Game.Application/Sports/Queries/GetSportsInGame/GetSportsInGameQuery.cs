using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Queries.GetSportsInGame
{
    public class GetSportsInGameQuery : IRequest<ErrorOr<GetSportsInGameResult>>
    {
        public int Id { get; set; }

        public GetSportsInGameQuery(int id)
        {
            Id = id;
        }
    }
}
