using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Players.Request
{
    public class DeletePlayerRequest
    {
        public int Id { get; set; }

        public DeletePlayerRequest(int id)
        {
            Id = id;
            
        }
    }
}
