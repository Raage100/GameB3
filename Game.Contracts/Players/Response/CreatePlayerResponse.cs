using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Players.Response
{
    public class CreatePlayerResponse
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
    }
}
