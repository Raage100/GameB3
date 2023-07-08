using Game.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Players.Queries
{
    public class GetPlayersInGameResult
    {
        public List<Player> PLayers { get; set; }

        public GetPlayersInGameResult(List<Player> players)
        {
            PLayers = players;
        }
    }
}
