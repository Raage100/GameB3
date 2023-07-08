using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Players.Response
{
    public class DeletePlayerResponse
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public DeletePlayerResponse(int id, bool deleted)
        {
            Id = id;
            Deleted = deleted;
        }
    }
}
