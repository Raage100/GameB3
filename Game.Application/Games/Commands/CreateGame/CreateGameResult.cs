using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Games.Commands.CreateGame
{
    public class CreateGameResult
    {
        public int Id { get; set; }
        public bool Created { get; set; }



        public CreateGameResult(int id, bool created)
        {
            Id = id;
            Created = created;
        }  

   
    }
}
