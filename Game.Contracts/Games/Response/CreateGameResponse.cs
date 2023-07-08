using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Contracts.Games.Response
{
    public class CreateGameResponse
    {
        public int Id { get; set; }
        public bool Created { get; set; }

        public CreateGameResponse(int id, bool created)
        {
            Id = id;
            Created = created;

        }
    }
}
