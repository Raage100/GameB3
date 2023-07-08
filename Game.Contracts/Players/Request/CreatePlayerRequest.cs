using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Players.Request
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public int GameId { get; set; }

        public CreatePlayerRequest(string name, int gameId)
        {
            Name = name;
            GameId = gameId;
            
        }
    }
}
