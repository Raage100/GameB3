using Game.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Sports.Queries.GetSportsInGame
{
    public class GetSportsInGameResult
    {
        public List<Sport> Sports { get; set; }

        public GetSportsInGameResult(List<Sport> sports)
        {
            Sports = sports;
        }
    }
}
