using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Players.Response
{
    public class GetPlayersInGameResponse
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
    }
}
