using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Sports.Request
{
    public class CreateSportRequest
    {
        public string Name { get; set; }
        public int GameId { get; set; }

        public CreateSportRequest(string name, int gameId)
        {
            Name = name;
            GameId = gameId;
            
        }
    }
}
